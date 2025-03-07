using System.Threading.Tasks;
using Code.Audios.Audio;
using Code.Audios.Audio.Factory;
using Code.Gameplay;
using Code.Gameplay.GameLoop;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Gameplay.Windows.UpdatableWindows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;

namespace Code.Meta.UI.HUD.PauseWindow
{
    public class PauseWindowModel
    {
        private readonly IAudioFactory _audioFactory;
        private readonly IUpdatableWindowService _staticWindowService;
        private readonly IBattleFeatureService _battleFeatureService;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly UpdatableWindowId _id;

        public PauseWindowModel(
            UpdatableWindowId staticWindowId,
            IAudioFactory audioFactory, 
            IUpdatableWindowService staticWindowService, 
            IBattleFeatureService battleFeatureService, 
            IGameStateMachine gameStateMachine)
        {
            _id = staticWindowId;
            _audioFactory = audioFactory;
            _staticWindowService = staticWindowService;
            _battleFeatureService = battleFeatureService;
            _gameStateMachine = gameStateMachine;
        }
        
        public async void ReturnHome()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _staticWindowService.Close(_id);
            await Task.Delay(100);
            _battleFeatureService.Deactivate();
            _gameStateMachine.Enter<LoadingHomeScreenState>();
        }

        public void Continue()
        {
            _staticWindowService.Close(_id);
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _gameStateMachine.Enter<BattleLoopState>();
        }
    }
}