using Code.Infrastructure.Views.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars.GameEntityRegistrars
{
    public class Rigidbody2DRegistrar : GameEntityComponentRegistrar
    {
        public Rigidbody2D Rigidbody2D;
        public override void RegisterComponents()
        {
            Entity
                .AddRigidbody2D(Rigidbody2D);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasRigidbody2D)
            {
                Entity
                    .RemoveRigidbody2D();
            }
        }
    }
}