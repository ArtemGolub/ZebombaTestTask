using System;
using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.AssetManagement.Constants;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Code.Infrastructure.AssetManagement
{
    public class LabeledAssetDownloadService: IAssetDownloadService
    {
        private readonly IAssetDownloadReporter _downloadReporter;
        private long _downloadSize;

        public LabeledAssetDownloadService(IAssetDownloadReporter downloadReporter)
        {
            _downloadReporter = downloadReporter;
        }

        public async UniTask InitializeDownloadDataAsync()
        {
            await Addressables.InitializeAsync().ToUniTask();
            await UpdateCatalogsAsync();
            await UpdateDownloadSizeAync();
        }

        public float GetDownloadSizeMb() => SizeToMb(_downloadSize);

        public async UniTask UpdateContentAsync()
        {
            try
            {
                AsyncOperationHandle downloadHandle = Addressables.DownloadDependenciesAsync(DownloadServiceConstants.LocalLabel);

                while (!downloadHandle.IsDone && downloadHandle.IsValid())
                {
                    await UniTask.Yield();
                    _downloadReporter.Report(downloadHandle.GetDownloadStatus().Percent);
                }

                _downloadReporter.Report(1);
                if (downloadHandle.Status == AsyncOperationStatus.Failed)
                    Debug.LogError("Error downloading content");

                if (downloadHandle.IsValid())
                    Addressables.Release(downloadHandle);

                _downloadReporter.Reset();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async UniTask UpdateCatalogsAsync()
        {
            List<string> catalogsToUpdate = await Addressables.CheckForCatalogUpdates().ToUniTask();
            if (catalogsToUpdate.IsNullOrEmpty())
                return;
            
            await Addressables.UpdateCatalogs(catalogsToUpdate).ToUniTask();
        }
        
        
        // TODO Try Catch
        private async UniTask UpdateDownloadSizeAync()
        {
            try
            {
                _downloadSize = await Addressables
                    .GetDownloadSizeAsync(DownloadServiceConstants.LocalLabel)
                    .ToUniTask();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private static float SizeToMb(long downloadSize) => downloadSize * 1f / 1048576;
    }
}