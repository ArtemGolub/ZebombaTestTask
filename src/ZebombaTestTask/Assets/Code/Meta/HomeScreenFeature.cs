using Code.Audios.Audio;
using Code.Common.Destruct;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Views;

namespace Code.Meta
{
  public class HomeScreenFeature : Feature
  {
    public HomeScreenFeature(ISystemFactory systems)
    {
      Add(systems.Create<BindViewFeature>());
      Add(systems.Create<AudioFeature>());
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}