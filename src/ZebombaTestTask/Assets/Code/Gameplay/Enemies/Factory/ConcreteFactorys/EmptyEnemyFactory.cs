using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.AssetManagement.Constants;
using Code.Infrastructure.Identifiers;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Enemies.Factory.ConcreteFactorys
{
    public class EmptyEnemyFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly EnemyPool _enemyPool;
        private string[] _prefabNames;

        public EmptyEnemyFactory(IIdentifierService identifierService, EnemyPool enemyPool)
        {
            _identifierService = identifierService;
            _enemyPool = enemyPool;
            
            LoadPrefabNames().Forget();
        }

        public GameEntity GetOrCreateEmptyEnemy(Vector3 at)
        {
            var goblinEntity = _enemyPool.GetEnemy(EnemyTypeId.Empty);

            if (goblinEntity != null)
            {
                ActivateEmptyEnemy(goblinEntity, at);
                
                return goblinEntity;
            }
            else
            {
                return CreateEnemy(at);
            }
        }

        private void ActivateEmptyEnemy(GameEntity entity, Vector3 at)
        {
            entity
                .ReplaceWorldPosition(at)
                .ReplaceDirection(Vector2.zero)
                .ReplaceViewPath(GetRandomPrefab());
        }

        private GameEntity CreateEnemy(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddEnemyTypeId(EnemyTypeId.Empty)
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .With(e => e.isEnemy = true)
                .AddViewPath(GetRandomPrefab());
        }

        private string GetRandomPrefab()
        {
            if (_prefabNames == null || _prefabNames.Length == 0)
            {
                Debug.LogError("Prefab names are not loaded.");
                return string.Empty;
            }
            
            string prefabName = _prefabNames[Random.Range(0, _prefabNames.Length)];
            string randomPrefabName = $"{PrefabsDirectoryConstants.RandomEnemyPrefabPath}{prefabName}";
            return randomPrefabName;
        }
        
        private async UniTask LoadPrefabNames()
        {
            try
            {
                var handle = Addressables.LoadAssetsAsync<GameObject>(PrefabsDirectoryConstants.RandomEnemyPrefabPath, null);
                IList<GameObject> prefabs = await handle.ToUniTask();
                
                _prefabNames = prefabs.Select(prefab => prefab.name).ToArray();
                Addressables.Release(handle);
            }
            catch (InvalidKeyException ex)
            {
                Debug.LogError($"[LoadPrefabNames] Invalid key for label {PrefabsDirectoryConstants.RandomEnemyPrefabPath}. Exception: {ex}");
                _prefabNames = Array.Empty<string>();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[LoadPrefabNames] An error occurred. Exception: {ex}");
                _prefabNames = Array.Empty<string>();
            }
        }
    }
}
