using Code.Infrastructure.Views.Registrars;

namespace Code.Gameplay.Common.Registrars.GameEntityRegistrars
{
    public class TransfromRegistrar : GameEntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity
                .AddTransform(transform);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasTransform)
            {
                Entity
                    .RemoveTransform();
            }
        }
    }
}