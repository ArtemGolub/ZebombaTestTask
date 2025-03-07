using Code.Infrastructure.Views.AudioViews;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.Views.Fabrics
{
    public interface IAudioEntityViewFactory
    {
        UniTask<AudioEntityBehaviour> CreateViewForEntity(AudioEntity entity);
        AudioEntityBehaviour CreateViewForEntityFromPrefab(AudioEntity entity);
    }
}