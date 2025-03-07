using Entitas;

namespace Code.Gameplay.Enemies.Systems
{
    public class ChaseHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        public ChaseHeroSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.WorldPosition,
                GameMatcher.Chasing
            ));
            
            _heroes = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.WorldPosition
            ));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity enemy in _enemies)
            {
                enemy.ReplaceDirection((hero.WorldPosition - enemy.WorldPosition).normalized);
                enemy.isMoving = true;
            }
        }
    }
}