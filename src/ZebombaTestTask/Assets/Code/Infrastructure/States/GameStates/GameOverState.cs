using Code.Gameplay;
using Code.Gameplay.Cameras.Factory;
using Code.Gameplay.GameLoop;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Progress.SaveLoad;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class GameOverState : EndOfFrameExitState
  {
    private readonly IStaticWindowService _staticWindowService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly IBattleFeatureService _battleFeatureService;
    private readonly GameContext _gameContext;

    public GameOverState(
      IStaticWindowService staticWindowService,
      ISaveLoadService saveLoadService, IBattleFeatureService battleFeatureService)
    {
      _staticWindowService = staticWindowService;
      _saveLoadService = saveLoadService;
      _battleFeatureService = battleFeatureService;
    }

    public override void Enter()
    {
      _battleFeatureService.Deactivate();
      _saveLoadService.SaveProgress();
      _staticWindowService.Open(StaticWindowId.GameOverWindow);
    }

    protected override void ExitOnEndOfFrame()
    {
        
    }
  }
}