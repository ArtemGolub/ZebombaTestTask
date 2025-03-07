using Code.Audios.Audio.Factory;
using Code.Gameplay;
using Code.Gameplay.GameLoop;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Gameplay.Windows.UpdatableWindows;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD.PauseWindow
{
    public class PauseWindowController : UpdatableWindow
    {
        [SerializeField] private Button ReturnHomeButton;
        [SerializeField] private Button ContinueButton;

        private PauseWindowModel _model;

        [Inject]
        private void Construct(
            IGameStateMachine stateMachine, 
            IUpdatableWindowService updatableWindowService, 
            IAudioFactory audioFactory, 
            IBattleFeatureService battleFeatureService)
        {
            Id = UpdatableWindowId.PauseWindow;
            _model = new PauseWindowModel(Id, audioFactory, updatableWindowService, battleFeatureService, stateMachine);
        }

        protected override void Initialize()
        {
            ReturnHomeButton.onClick.AddListener(_model.ReturnHome);
            ContinueButton.onClick.AddListener(_model.Continue);
        }
        protected override void Cleanup()
        {
            ReturnHomeButton.onClick.RemoveListener(_model.ReturnHome);
            ContinueButton.onClick.RemoveListener(_model.Continue);
        }


    }
}
