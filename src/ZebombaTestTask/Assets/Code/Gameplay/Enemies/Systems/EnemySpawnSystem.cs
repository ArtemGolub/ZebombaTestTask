using Code.Common.Extensions;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Enemies.Factory;
using Code.Gameplay.StaticData;
using Code.Gameplay.StaticData.WindowsStaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Enemies.Systems
{
    public class EnemySpawnSystem : IExecuteSystem
    {
        private const float SpawnDistanceGap = 1f;
        
        private readonly ITimeService _timeService;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IWindowsStaticDataService _windowsStaticDataService;

        private readonly IGroup<GameEntity> _timers;
        private readonly IGroup<GameEntity> _cameras;

        public EnemySpawnSystem(GameContext contextParameter, 
            ITimeService timeService, IEnemyFactory enemyFactory, IWindowsStaticDataService windowsStaticDataService)
        {
            _timeService = timeService;
            _enemyFactory = enemyFactory;
            _windowsStaticDataService = windowsStaticDataService;
            _timers = contextParameter.GetGroup(
                GameMatcher.SpawnTimer
            );
            
            _cameras = contextParameter.GetGroup(GameMatcher.AllOf(
                GameMatcher.Camera,
                GameMatcher.MainCamera
            ));
        }

        public void Execute()
        {
            foreach (GameEntity timer in _timers)
            {
                timer.ReplaceSpawnTimer(timer.SpawnTimer - _timeService.DeltaTime);
                if (timer.SpawnTimer <= 0)
                {
                    timer.ReplaceSpawnTimer(4);
                    SpawnEnemiesOutsideCamera();
                }
            }
        }

        private void SpawnEnemiesOutsideCamera()
        {
            foreach (GameEntity cameraEntity in _cameras)
            { 
                var camera = cameraEntity.Camera;
               GameEntity enemy = _enemyFactory.CreateEnemy(
                    EnemyTypeId.Empty, 
                    at: RandomSpawnPositionOutsideCamera(camera));
            }
        }
        
        private Vector2 RandomSpawnPositionOutsideCamera(Camera camera)
        {
            bool startWithHorizontal = Random.Range(0, 2) == 0;

            return startWithHorizontal 
                ? HorizontalSpawnPositionOutsideCamera(camera) 
                : VerticalSpawnPositionOutsideCamera(camera);
        }

        private Vector2 HorizontalSpawnPositionOutsideCamera(Camera camera)
        {
            Vector2[] horizontalDirections = { Vector2.left, Vector2.right };
            Vector2 primaryDirection = horizontalDirections.PickRandom();
      
            float horizontalOffsetDistance = GetScreenWorldWidth(camera) / 2 + SpawnDistanceGap;
            float verticalRandomOffset = Random.Range(-GetScreenWorldHeight(camera) / 2, GetScreenWorldHeight(camera) / 2);

            return (Vector2)camera.transform.position + primaryDirection * horizontalOffsetDistance + Vector2.up * verticalRandomOffset;
        }

        private Vector2 VerticalSpawnPositionOutsideCamera(Camera camera)
        {
            Vector2[] verticalDirections = { Vector2.up, Vector2.down };
            Vector2 primaryDirection = verticalDirections.PickRandom();
      
            float verticalOffsetDistance = GetScreenWorldHeight(camera) / 2 + SpawnDistanceGap;
            float horizontalRandomOffset = Random.Range(-GetScreenWorldWidth(camera) / 2, GetScreenWorldWidth(camera) / 2);
            
            return (Vector2)camera.transform.position + primaryDirection * verticalOffsetDistance + Vector2.right * horizontalRandomOffset;
        }

        private float GetScreenWorldWidth(Camera camera)
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            float worldHeight = camera.orthographicSize * 2;
            return (screenWidth / screenHeight) * worldHeight;
        }

        private float GetScreenWorldHeight(Camera camera)
        {
            return camera.orthographicSize * 2;
        }
    }
}
