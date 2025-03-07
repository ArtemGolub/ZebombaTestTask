using Code.Audios.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD.GameOverWindow
{
    public class GameOverWindow : StaticWindow
    {
        [SerializeField] private Button btnReturnHome;
        [SerializeField] private Button btnRestart;
        
        private GameOverWindowModel _model;
        
        private IGameStateMachine _stateMachine;
        private IStaticWindowService _staticWindowService;
        private IAudioFactory _audioFactory;

        [Inject]
        private void Construct(
            IGameStateMachine stateMachine, 
            IStaticWindowService staticWindowService, 
            IAudioFactory audioFactory)
        {
            Id = StaticWindowId.GameOverWindow;
            
            _stateMachine = stateMachine;
            _staticWindowService = staticWindowService;
            _audioFactory = audioFactory;
        }

        protected override void Initialize()
        {
            _model = new GameOverWindowModel(Id, _stateMachine, _staticWindowService, _audioFactory);
        }

        protected override void SubscribeUpdates()
        {
            btnReturnHome.onClick.AddListener(_model.ReturnHome);
            btnRestart.onClick.AddListener(_model.Restart);
        }

        protected override void UnsubscribeUpdates()
        {
            btnReturnHome.onClick.RemoveAllListeners();
            btnRestart.onClick.RemoveAllListeners();
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            _model = null;
        }
    }
}