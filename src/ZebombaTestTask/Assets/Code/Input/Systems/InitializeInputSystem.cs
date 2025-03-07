using Code.Common.Entity;
using Entitas;

namespace Code.Input.Systems
{
    public class InitializeInputSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateInputEntity.Empty()
                .isInput = true;
        }
    }
}