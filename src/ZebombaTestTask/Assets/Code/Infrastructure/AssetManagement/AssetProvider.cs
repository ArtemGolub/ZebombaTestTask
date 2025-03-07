using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {

        public async UniTask<T> LoadAsset<T>(string path) where T : Component
        {
            try
            {
                var handle = Addressables.LoadAssetAsync<GameObject>(path);
                var prefab = await handle.ToUniTask();
                
                if (prefab.TryGetComponent<T>(out var component))
                {
                    return component;
                }
                else
                {
                    Debug.LogError($"[LoadAsset] Component of type {typeof(T)} not found in prefab at path: {path}");
                    return null;
                }
            }
            catch (InvalidKeyException ex)
            {
                Debug.LogError($"[LoadAsset] Invalid key or type mismatch for path: {path}. Exception: {ex}");
                return null;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[LoadAsset] An error occurred while loading asset from path: {path}. Exception: {ex}");
                return null;
            }
        }

        public async UniTask<T> LoadScriptable<T>(string path) where T : ScriptableObject
        {
            try
            {
                return await Addressables.LoadAssetAsync<T>(path).ToUniTask();
            }
            catch (InvalidKeyException ex)
            {
                Debug.LogError($"[LoadScriptable] Invalid key or type mismatch for path: {path}. Exception: {ex}");
                return null;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[LoadScriptable] An error occurred while loading scriptable object from path: {path}. Exception: {ex}");
                return null;
            }
        }

        public async UniTask<string[]> LoadPrefabNames(string label)
        {
            try
            {
                var handle = Addressables.LoadAssetsAsync<GameObject>(label, null);
                IList<GameObject> prefabs = await handle.ToUniTask();
                
                string[] prefabNames = prefabs.Select(prefab => prefab.name).ToArray();
                
                Addressables.Release(handle);

                return prefabNames;
            }
            catch (InvalidKeyException ex)
            {
                Debug.LogError($"[LoadPrefabNames] Invalid key or type mismatch for label: {label}. Exception: {ex}");
                return Array.Empty<string>();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[LoadPrefabNames] An error occurred while loading prefabs for label: {label}. Exception: {ex}");
                return Array.Empty<string>();
            }
        }
    }
}