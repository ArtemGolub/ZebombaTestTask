using System;
using Code.Audios.Audio;
using Code.Audios.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Gameplay.Windows.UpdatableWindows;
using Code.Progress.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.HUD
{
    public class GameplayHUD: MonoBehaviour
    {
        private IAudioFactory _audioFactory;
        private IStaticWindowService _staticWindowService;
        private IUpdatableWindowService _updatableWindowService;

        [Inject]
        private void Construct(ISaveLoadService saveLoadService,IAudioFactory audioFactory, IStaticWindowService staticWindowService, IUpdatableWindowService updatableWindowService)
        {
            _audioFactory = audioFactory;
            _staticWindowService = staticWindowService;
            _updatableWindowService = updatableWindowService;
        }
        
        private void Start()
        {
            _audioFactory.CreateMusic(MusicTypeId.GameTheme);
            _updatableWindowService.Open(UpdatableWindowId.PauseWindow);
            // _windowService.Open(WindowId.CurrentScoreWindow);
            //  _windowService.Open(WindowId.PauseButtonWindow);
        }

        private void OnApplicationQuit()
        {
            
        }
    }
}
