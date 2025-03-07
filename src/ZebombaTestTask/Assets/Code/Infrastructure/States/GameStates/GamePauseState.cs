using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Gameplay.Windows.UpdatableWindows;
using Code.Infrastructure.States.StateInfrastructure;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    public class GamePauseState:  SimpleState
    {
        private readonly IStaticWindowService _staticWindowService;
        private readonly IUpdatableWindowService _updatableWindowService;

        public GamePauseState(
            IStaticWindowService staticWindowService, IUpdatableWindowService updatableWindowService)
        {
            _staticWindowService = staticWindowService;
            _updatableWindowService = updatableWindowService;
        }
    
        public override void Enter()
        {
            _updatableWindowService.Open(UpdatableWindowId.PauseWindow);
        }
    }
}