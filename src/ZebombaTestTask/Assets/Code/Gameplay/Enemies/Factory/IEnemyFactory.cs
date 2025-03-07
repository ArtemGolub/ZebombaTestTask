using UnityEngine;

namespace Code.Gameplay.Enemies.Factory
{
    public interface IEnemyFactory
    {
        GameEntity CreateEnemy(EnemyTypeId typeID, Vector3 at);
        void RecycleEnemy(GameEntity entity);
        void ClearPool();
    }
}