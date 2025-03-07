using Code.Audios.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Gameplay.Windows.UpdatableWindows;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI.HUD.PauseWindow.PauseButton.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD.PauseWindow.PauseButton
{
    public class GamePauseButtonController : UpdatableWindow
    {
        [SerializeField] private Button PauseButton;
    
        private GamePauseButtonModel _model;
        private IGamePauseButtonService _gamePauseButtonService;
        private IUpdatableWindowService _updtatableWindowService;

        [Inject]
        private void Construct(
            IUpdatableWindowService staticWindowService,
            IGameStateMachine stateMachine, 
            IAudioFactory audioFactory, 
            IGamePauseButtonService gamePauseButtonService)
        {
            Id = UpdatableWindowId.PauseButtonWindow;
            _model = new GamePauseButtonModel(stateMachine, audioFactory);
            _gamePauseButtonService = gamePauseButtonService;
            _updtatableWindowService = staticWindowService;
        }
    
        protected override void Initialize()
        {
            _gamePauseButtonService.SetGamePauseButton(this);
            PauseButton.onClick.AddListener(_model.Pause);
        }

        protected override void Cleanup()
        {
            _gamePauseButtonService.SetGamePauseButton(null);
            PauseButton.onClick.RemoveListener(_model.Pause);
            _updtatableWindowService.Close(Id);
        }
    }
}
