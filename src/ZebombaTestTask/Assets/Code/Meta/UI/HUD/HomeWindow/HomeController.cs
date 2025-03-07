using Code.Audios.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD.HomeWindow
{
    public class HomeController: StaticWindow
    {
        [SerializeField]private Button btnStartGame;
        [SerializeField]private Button btnSettings;
        [SerializeField]private Button btnPrivacy;
        
        private HomeModel _homeModel;
        
        private IGameStateMachine _stateMachine;
        private IAudioFactory _audioFactory;
        private IStaticWindowService _staticWindowService;
        
        [Inject]
        private void Construct(            
            IGameStateMachine gameStateMachine, 
            IAudioFactory audioFactory,
            IStaticWindowService staticWindowService)
        {
            Id = StaticWindowId.HomeWindow;
            _stateMachine = gameStateMachine;
            _audioFactory = audioFactory;
            _staticWindowService = staticWindowService;
        }
        
        protected override void Initialize()
        {
            _homeModel = new HomeModel(_stateMachine, _audioFactory, _staticWindowService);
        }

        protected override void SubscribeUpdates()
        {
            btnStartGame.onClick.AddListener(OnBtnStartGame);
            btnSettings.onClick.AddListener(OnBtnSettings);
            btnPrivacy.onClick.AddListener(OnBtnPrivacy);
        }

        protected override void UnsubscribeUpdates()
        {
            btnStartGame.onClick.RemoveAllListeners();
            btnSettings.onClick.RemoveAllListeners();
            btnPrivacy.onClick.RemoveAllListeners();
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            _homeModel = null;
        }

        private void OnBtnStartGame()
        {
            btnStartGame.interactable = false;
            _homeModel.EnterBattleLoadingState();
        }

        private void OnBtnSettings()
        {
            _homeModel.Settings();
        }

        private void OnBtnPrivacy()
        {
            _homeModel.Privacy();
        }
    }
}