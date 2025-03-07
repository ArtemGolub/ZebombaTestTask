using Code.Audios.Audio;
using Code.Common.Destruct;
using Code.Gameplay.Cameras;
using Code.Gameplay.CharacterStats;
using Code.Gameplay.Enemies;
using Code.Gameplay.GameOver.Systems;
using Code.Gameplay.Hero;
using Code.Gameplay.LifeTime;
using Code.Gameplay.Movement;
using Code.Gameplay.Physics;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Views;
using Code.Input;

namespace Code.Gameplay.GameLoop
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            NormalInit(systems);
        }

        private void NormalInit(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<BindViewFeature>());

            Add(systems.Create<HeroFeature>());
            Add(systems.Create<CameraFeature>());


           // Add(systems.Create<EnemyFeature>());
            Add(systems.Create<DeathFeature>());


            Add(systems.Create<GameOverOnHeroDeathSystem>());

            
            Add(systems.Create<PhysicsFeature>());
            Add(systems.Create<MovementFeature>());
       
            
            Add(systems.Create<StatsFeature>());
            Add(systems.Create<AudioFeature>());


            Add(systems.Create<ProcessDestructedFeature>());
        }

        private void ProfilerInit(ISystemFactory systems)
        {
           // ProfilerHelper.ProfileAction("Input Feature", () => Add(systems.Create<InputFeature>()));
        }
    }
}