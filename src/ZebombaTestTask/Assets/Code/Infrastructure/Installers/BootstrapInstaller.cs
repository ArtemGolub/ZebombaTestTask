using Code.Audios.Audio.Factory;
using Code.Audios.Audio.Services;
using Code.Gameplay.Cameras;
using Code.Gameplay.Cameras.Factory;
using Code.Gameplay.Common.AABB;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Enemies.Factory;
using Code.Gameplay.Floors.Factories;
using Code.Gameplay.GameLoop;
using Code.Gameplay.Hero.Factory;
using Code.Gameplay.Levels;
using Code.Gameplay.Physics.Factories;
using Code.Gameplay.StaticData.WindowsStaticData;
using Code.Gameplay.Windows.StaticWindows;
using Code.Gameplay.Windows.UpdatableWindows;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Views.Fabrics;
using Code.Input.Service;
using Code.Meta.UI.HUD.LoadingWindow;
using Code.Meta.UI.HUD.PauseWindow.PauseButton.Services;
using Code.Meta.UI.HUD.PauseWindow.Services;
using Code.Meta.UI.HUD.SettingsWindow.Services;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using RSG;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        [SerializeField]private LoadingController loadingController;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindAssetManagementServices();
            BindCommonServices();
            BindSystemFactory();
            BindUIFactories();
            BindContexts();
            BindGameplayServices();
            BindUIServices();
            BindAuidioServices();
            BindCameraProvider();
            BindGameplayFactories();
            BindStateMachine();
            BindStateFactory();
            BindInfrastructureServices();
            BindGameStates();
            BindProgressServices();
            BindPhysicsFactories();
        }
        
        private void BindPhysicsFactories()
        {
            Container.Bind<IForceFactory>().To<ForceFactory>().AsSingle();
        }
        
        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }

        private void BindStateFactory()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadResourcesState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActualizeProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingHomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleEnterState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GamePauseState>().AsSingle();
        }

        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();

            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
            Container.Bind<MetaContext>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
            Container.Bind<AudioContext>().FromInstance(Contexts.sharedInstance.audio).AsSingle();
        }

        private void BindCameraProvider()
        {
            Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
        }

        private void BindProgressServices()
        {
            Container.Bind<IProgressProvider>().To<ProgressProvider>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();

        }

        private void BindGameplayServices()
        {
            Container.Bind<IWindowsStaticDataService>().To<WindowsStaticDataService>().AsSingle();
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();
            Container.Bind<IBattleFeatureService>().To<BattleFeatureService>().AsSingle();
        }

        private void BindGameplayFactories()
        {
            Container.Bind<IGameEntityViewFactory>().To<GameGameEntityViewFactory>().AsSingle();
            Container.Bind<IAudioEntityViewFactory>().To<AudioEntityViewFactory>().AsSingle();
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
            Container.Bind<IAudioFactory>().To<AudioFactory>().AsSingle();
            Container.Bind<IFloorFactory>().To<FloorFactory>().AsSingle();
        }


        private void BindSystemFactory()
        {
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
        }

        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IAssetDownloadReporter>().To<AssetDownloadReporter>().AsSingle();
          //  Container.Bind<IAssetDownloadService>().To<AssetDownloadService>().AsSingle();
            Container.Bind<IAssetDownloadService>().To<LabeledAssetDownloadService>().AsSingle();
        }

        private void BindCommonServices()
        {
            Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IAABBPhysicsService>().To<AABBPhysicsService>().AsSingle();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }

        private void BindUIServices()
        {
            Container.BindInterfacesAndSelfTo<LoadingController>().FromComponentInNewPrefab(loadingController).AsSingle();
            
            Container.Bind<IStaticWindowService>().To<StaticWindowService>().AsSingle();
            Container.Bind<IUpdatableWindowService>().To<UpdatableWindowService>().AsSingle();
            Container.Bind<IGamePauseButtonService>().To<GamePauseButtonService>().AsSingle();
            Container.Bind<IPauseWindowService>().To<PauseWindowService>().AsSingle();
        }

        private void BindAuidioServices()
        {
            Container.Bind<ISettingsService>().To<SettingsService>().AsSingle();
        }

        private void BindUIFactories()
        {
            Container.Bind<IStaticWindowFactory>().To<StaticWindowFactory>().AsSingle();
            Container.Bind<IUpdatableWindowFactory>().To<UpdatableWindowFactory>().AsSingle();
        }

        public void Initialize()
        {
            Promise.UnhandledException += LogPromiseException;
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }


        private void LogPromiseException(object sender, ExceptionEventArgs e)
        {
            Debug.LogError(e.Exception);
        }
    }
}