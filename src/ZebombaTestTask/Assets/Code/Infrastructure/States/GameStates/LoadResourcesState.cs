using System;
using Code.Audios.Audio.Services;
using Code.Gameplay.StaticData.WindowsStaticData;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    public class LoadResourcesState : SimpleState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IAssetDownloadService _downloadService;
        private readonly IWindowsStaticDataService _windowsStaticDataService;
        private readonly IAudioService _audioService;


        public LoadResourcesState(
            IGameStateMachine stateMachine,
            IAssetDownloadService downloadService,
            IWindowsStaticDataService windowsStaticDataService,
            IAudioService audioService
        )
        {
            _stateMachine = stateMachine;
            _downloadService = downloadService;
            _windowsStaticDataService = windowsStaticDataService;
            _audioService = audioService;
        }

        public override async void Enter()
        {
            await LoadContent();
            await _windowsStaticDataService.LoadAll();
            await _audioService.LoadAll();
            
            _stateMachine.Enter<LoadProgressState>();
        }

        private async UniTask LoadContent()
        {
            await _downloadService.InitializeDownloadDataAsync();
            float downloadSize = _downloadService.GetDownloadSizeMb();
            Debug.Log($"Download size: {downloadSize} Mb");

            if (downloadSize > 0)
                await _downloadService.UpdateContentAsync();
        }
    }
}