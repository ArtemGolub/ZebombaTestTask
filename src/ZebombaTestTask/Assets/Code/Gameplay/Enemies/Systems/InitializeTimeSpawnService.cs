using Code.Common.Entity;
using Code.Gameplay.Const;
using Entitas;

namespace Code.Gameplay.Enemies.Systems
{
    public class InitializeTimeSpawnService: IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty().AddSpawnTimer(GameplayConstans.EnemySpawnTimer);
        }
    }
}