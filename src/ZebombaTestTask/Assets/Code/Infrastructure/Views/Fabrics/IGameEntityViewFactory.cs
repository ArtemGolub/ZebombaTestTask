using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.Views.Fabrics
{
    public interface IGameEntityViewFactory
    {
        UniTask<GameEntityBehaviour> CreateViewForEntityFromAddresable(GameEntity entity);
        GameEntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity);
    }
}