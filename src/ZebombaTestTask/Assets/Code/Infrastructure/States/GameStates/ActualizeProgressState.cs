﻿using System;
using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Meta;
using Code.Meta.Features.Simulation;
using Code.Progress.Data;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class ActualizeProgressState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ITimeService _time;
    private readonly IProgressProvider _progressProvider;
    private readonly ISystemFactory _systemFactory;
    private ActualizationFeature _actualizationFeature;
    private readonly TimeSpan _twoDays = TimeSpan.FromDays(2);
    private readonly ISaveLoadService _saveLoadService;

    
    public ActualizeProgressState(
      IGameStateMachine stateMachine,
      ITimeService time,
      IProgressProvider progressProvider,
      ISaveLoadService saveLoadService,
      ISystemFactory systemFactory)
    {
      _saveLoadService = saveLoadService;
      _stateMachine = stateMachine;
      _time = time;
      _progressProvider = progressProvider;
      _systemFactory = systemFactory;
    }
    
    public override void Enter()
    {
      _actualizationFeature = _systemFactory.Create<ActualizationFeature>();
      
      ActualizeProgress(_progressProvider.ProgressData);
      
      _stateMachine.Enter<LoadingHomeScreenState>();
    }
    
    private void ActualizeProgress(ProgressData data)
    {
      _actualizationFeature.Initialize();
      _actualizationFeature.DeactivateReactiveSystems();
      
      _actualizationFeature.Execute();
      _actualizationFeature.Cleanup();

      _saveLoadService.SaveProgress();
    }
    
    protected override void Exit()
    {
      _actualizationFeature.Cleanup();
      _actualizationFeature.TearDown();
      _actualizationFeature = null;
    }
  }
}