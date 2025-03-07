using Code.Gameplay;
using Code.Gameplay.Cameras;
using Code.Gameplay.Cameras.Factory;
using Code.Gameplay.Floors.Factories;
using Code.Gameplay.GameLoop;
using Code.Gameplay.Hero.Factory;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class BattleEnterState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IHeroFactory _heroFactory;
    private readonly ICameraFactory _cameraFactory;
    private readonly IFloorFactory _floorFactory;
    private readonly ICameraProvider _cameraProvider;
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;
    private BattleFeature _battleFeature;

    public BattleEnterState(
      IGameStateMachine stateMachine, 
      ILevelDataProvider levelDataProvider, 
      IHeroFactory heroFactory,
      ICameraFactory cameraFactory,
      IFloorFactory floorFactory)
    {
      _stateMachine = stateMachine;
      _levelDataProvider = levelDataProvider;
      _heroFactory = heroFactory;
      _cameraFactory = cameraFactory;
      _floorFactory = floorFactory;
    }
    
    public override void Enter()
    {
      PlaceHero();
      PlaceCamera();
      PlaceFloor();
      
      _stateMachine.Enter<BattleLoopState>();
    }

    
    private void PlaceCamera()
    {
       _cameraFactory.CreateCamera(_levelDataProvider.StartPoint);
       _cameraFactory.CreateBorderCamera(_levelDataProvider.StartPoint);
    }

    private void PlaceHero()
    {
      GameEntity hero = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
    }    
    
    private void PlaceFloor()
    {
      _floorFactory.CreateFloor(_levelDataProvider.StartPoint - new Vector3(0, 2f , 0));
    }
    
  }
}