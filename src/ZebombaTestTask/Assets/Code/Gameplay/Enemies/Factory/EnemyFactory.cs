using System;
using Code.Gameplay.Enemies.Factory.ConcreteFactorys;
using Code.Gameplay.StaticData;
using Code.Gameplay.StaticData.WindowsStaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        
        private readonly IWindowsStaticDataService _windowsStaticDataService;
        private readonly EnemyPool _enemyPool;
        private readonly EmptyEnemyFactory _emptyEnemyFactory;

        public EnemyFactory(IIdentifierService identifierService, IWindowsStaticDataService windowsStaticDataService)
        {
           
            _windowsStaticDataService = windowsStaticDataService;
            _enemyPool = new EnemyPool();
            _emptyEnemyFactory = new EmptyEnemyFactory(identifierService, _enemyPool);
        }
        public GameEntity CreateEnemy(EnemyTypeId typeID, Vector3 at)
        {
            switch (typeID)
            {
                case EnemyTypeId.Empty:
                    GameEntity enemy = _emptyEnemyFactory.GetOrCreateEmptyEnemy(at);
                    break;
                case EnemyTypeId.Unknown:
                    Debug.LogWarning($"Enemy with type id: {typeID} not implemented");
                    break;
                default:
                    throw new Exception($"Enemy with type id {typeID} does not exist");
            }
            return null;
        }

        
        public void RecycleEnemy(GameEntity entity)
        {
            entity.isEnemy = false;
            entity.isTurnedAlongDirection = false;
            entity.isMovementAvailable = false;

            _enemyPool.ReturnToPool(entity);
        }

        public void ClearPool()
        {
            _enemyPool.ClearPool();
        }
    }
}