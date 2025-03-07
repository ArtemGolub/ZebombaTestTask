using Code.Infrastructure.AssetManagement.Constants;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI.HUD.LoadingWindow;

namespace Code.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;
    private readonly LoadingController _loadingController;

    public BootstrapState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, LoadingController loadingController)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _loadingController = loadingController;
    }
    
    public override void Enter()
    {
      _sceneLoader.LoadSceneBuildIn(ScenesDirectoryConstants.LoadingScenePath, EnterLoadingState);
    }
    private void EnterLoadingState()
    {
      _loadingController.Show();
      _stateMachine.Enter<LoadResourcesState>();
    }
  }
}