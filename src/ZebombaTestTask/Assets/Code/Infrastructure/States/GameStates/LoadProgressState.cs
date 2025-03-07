using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Gameplay.StaticData.WindowsStaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.SaveLoad;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadProgressState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IWindowsStaticDataService _windowsStaticDataService;
    private readonly ISaveLoadService _saveLoadService;

    public LoadProgressState(
      IGameStateMachine stateMachine,
      ISaveLoadService saveLoadService,
      IWindowsStaticDataService windowsStaticDataService)
    {
      _saveLoadService = saveLoadService;
      _stateMachine = stateMachine;
      _windowsStaticDataService = windowsStaticDataService;
    }
    
    public override void Enter()
    {
      InitializeProgress();
      _stateMachine.Enter<ActualizeProgressState>();
    }

    private void InitializeProgress()
    {
      if (_saveLoadService.HasFileSavedProgress)
        _saveLoadService.LoadProgress();
      else
        CreateNewProgress();
    }

    private void CreateNewProgress()
    {
      _saveLoadService.CreateProgress();
      CreateMetaEntity.Empty()
        // Progress Data here
        ;
    }
  }
}