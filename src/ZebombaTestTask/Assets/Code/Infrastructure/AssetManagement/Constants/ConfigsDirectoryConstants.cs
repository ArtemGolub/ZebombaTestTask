namespace Code.Infrastructure.AssetManagement.Constants
{
    public class ConfigsDirectoryConstants
    {
        public const string MusicConfigSourcePath = "ConfigsFolder/Musics/MusicConfig.asset";
        public const string SoundConfigSourcePath = "ConfigsFolder/Sounds/SoundsConfig.asset";
        
        public const string StaticWindowsPath = "ConfigsFolder/Windows/StaticWindowConfig.asset";
        public const string UpdatableWindowsPath = "ConfigsFolder/Windows/UpdatableWindowConfig.asset";
    }
    
    public class ScenesDirectoryConstants
    {
        public const string HomeScreenPath = "HomeScreen";
        public const string LoadingScenePath = "LoadingScene";
    }    
    
    public class PrefabsDirectoryConstants
    {
        public const string AudioListenerPrefabSourcePath = "Gameplay/AudioSources/AudioListener.prefab";
        public const string MusicPrefabSourcePath = "Gameplay/AudioSources/MusicSource.prefab";
        public const string SoundPrefabSourcePath = "Gameplay/AudioSources/SoundSource.prefab";
        
        public const string HeroPrefabPath = "Gameplay/Hero/Hero.prefab";
        public const string FloorPrefabPath = "Gameplay/Floors/Floor.prefab";
        
        public const string MainCameraPrefabPath = "Gameplay/Cameras/MainCamera.prefab";
        public const string BorderCameraPrefabPath = "Gameplay/Cameras/BorderCamera.prefab";
        
        public const string RandomEnemyPrefabPath = "Gameplay/Enemy/";
    }

    public class DownloadServiceConstants
    {
        public const string RemoteLabel = "remote";
        public const string LocalLabel = "local";
    }
}