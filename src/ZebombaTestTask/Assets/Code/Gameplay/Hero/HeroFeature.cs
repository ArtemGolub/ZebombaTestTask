using Code.Gameplay.Hero.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Hero
{
    public class HeroFeature: Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeHeroSystem>());
            
            Add(systems.Create<SetHeroDirectionByInputSystem>());

            Add(systems.Create<HeroDeathSystem>());
            
            Add(systems.Create<FinalizeHeroDeathProcessSystem>());
        }
    }
}