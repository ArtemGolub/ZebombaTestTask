using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Infrastructure.Views
{
    public abstract class GameEntityDependent : MonoBehaviour
    {
        public GameEntityBehaviour GameEntityView;
        protected GameEntity Entity => GameEntityView != null ? GameEntityView.Entity : null;

        private void Awake()
        {
            if (!GameEntityView)
                GameEntityView = GetComponent<GameEntityBehaviour>();
        }

    }    

}