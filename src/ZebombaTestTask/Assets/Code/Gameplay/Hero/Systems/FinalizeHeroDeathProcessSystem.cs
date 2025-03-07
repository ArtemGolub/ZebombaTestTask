using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Hero.Systems
{
    public class FinalizeHeroDeathProcessSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new(1);

        public FinalizeHeroDeathProcessSystem(GameContext contextParameter)
        {
            _heroes = contextParameter.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Dead,
                GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes.GetEntities(_buffer))
            {
                hero.isProcessingDeath = false;
            }
        }
    }
}