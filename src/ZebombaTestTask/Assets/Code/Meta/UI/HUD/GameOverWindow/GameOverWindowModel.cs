using System.Threading.Tasks;
using Code.Audios.Audio;
using Code.Audios.Audio.Factory;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine.SceneManagement;

namespace Code.Meta.UI.HUD.GameOverWindow
{
    public class GameOverWindowModel
    {
        private readonly StaticWindowId _id;
        private IGameStateMachine _gameStateMachine;
        private IStaticWindowService _staticWindowService;
        private IAudioFactory _audioFactory;
        
        public GameOverWindowModel(StaticWindowId id,IGameStateMachine stateMachine, IStaticWindowService staticWindowService, IAudioFactory audioFactory)
        {
            _id = id;
            _gameStateMachine = stateMachine;
            _staticWindowService = staticWindowService;
            _audioFactory = audioFactory;
        }

        public void ReturnHome()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _staticWindowService.Close(_id);
            _gameStateMachine.Enter<LoadingHomeScreenState>();
        }

        public void Restart()
        {
            _audioFactory.CreateSound(SoundTypeId.BtnClick);
            _staticWindowService.Close(_id);
            
            _gameStateMachine.Enter<LoadingBattleState, string>(SceneManager.GetActiveScene().name);
        }
    }
}