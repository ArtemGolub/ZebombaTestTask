using Code.Infrastructure.Views.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars.GameEntityRegistrars
{
    public class SpriteRendererRegistrar : GameEntityComponentRegistrar
    {
        public SpriteRenderer SpriteRenderer;
        public override void RegisterComponents()
        {
            Entity
                .AddSpriteRenderer(SpriteRenderer);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasSpriteRenderer)
            {
                Entity
                    .RemoveSpriteRenderer();
            }
        }
    }
}