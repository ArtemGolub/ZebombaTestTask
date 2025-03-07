using Code.Audios.Audio;
using Code.Audios.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;

namespace Code.Meta.UI.HUD.HomeWindow
{
    public class HomeModel
    {
        private IGameStateMachine _stateMachine;
        private IAudioFactory _audioFactory;
        private IStaticWindowService _staticWindowService;

        public HomeModel(
            IGameStateMachine gameStateMachine,
            IAudioFactory audioFactory,
            IStaticWindowService staticWindowService)
        {
            _stateMachine = gameStateMachine;
            _audioFactory = audioFactory;
            _staticWindowService = staticWindowService;
        }

        public void EnterBattleLoadingState()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _staticWindowService.CloseAll();
            _stateMachine.Enter<LoadingBattleState, string>(MetaConstants.BattleSceneName);
        }

        public void Settings()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _staticWindowService.Close(StaticWindowId.HomeWindow);
            _staticWindowService.Open(StaticWindowId.SettingsWindow);
        }

        public void Privacy()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            // TODO Implement Privacy here
        }
    }
}