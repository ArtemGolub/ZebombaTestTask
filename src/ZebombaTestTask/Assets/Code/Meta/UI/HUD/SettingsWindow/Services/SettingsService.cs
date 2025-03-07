using Code.Audios.Audio.Factory;
using Code.Meta.UI.HUD.SettingsWindow.SliderSettings;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.HUD.SettingsWindow.Services
{
    public class SettingsService : ISettingsService
    {
        private ISettingsController _audioSettingsController;
        public bool IsUserInteracting { get; set; }
        public bool IsInitializing { get; set; }
        
        [Inject]
        private void Construct(IProgressProvider progressProvider, IAudioFactory audioFactory)
        {
            _progressProvider = progressProvider;
            
            SetCurrentMusicVolume(progressProvider.ProgressData.SettingsData.MusicVolume);
            audioFactory.CreateMusicVolumeChanger(GetCurrentMusicVolume());
            
            SetCurrentSoundVolume(progressProvider.ProgressData.SettingsData.SoundVolume);
            audioFactory.CreateSoundVolumeChanger(GetCurrentSoundVolume());
        }
        
        public ISettingsController SetAuidioSettingsController(ISettingsController settingsController)
        {
            _audioSettingsController = settingsController;
            return _audioSettingsController;
        }

        public void RemoveSettingsController()
        {
            _audioSettingsController = null;
        }

        public ISettingsController GetAudioSettingsController()
        {
            return _audioSettingsController;
        }
        
        public float GetCurrentMusicVolume()
        {
            return _currentMusicVolume;
        }

        public float GetCurrentSoundVolume()
        {
            return _currentSoundVolume;
        }

        private float _currentMusicVolume;
        private float _currentSoundVolume;
        private ISaveLoadService _saveLoadService;
        private IProgressProvider _progressProvider;

        public float SetCurrentMusicVolume(float volume)
        {
            _progressProvider.ProgressData.SettingsData.MusicVolume = volume;
            _currentMusicVolume = volume;
            Debug.Log($"{_currentMusicVolume}");
            return _currentMusicVolume;
        }

        public float SetCurrentSoundVolume(float volume)
        {
            _progressProvider.ProgressData.SettingsData.SoundVolume = volume;
            _currentSoundVolume = volume;
            return _currentSoundVolume;
        }
    }
}