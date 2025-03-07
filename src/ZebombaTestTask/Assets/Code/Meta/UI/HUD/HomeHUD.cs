using Code.Gameplay.Windows.StaticWindows;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.HUD
{
    public class HomeHUD : MonoBehaviour
    {
        private IStaticWindowService _staticWindowService;

        [Inject]
        private void Construct(IStaticWindowService staticWindowService)
        {
            _staticWindowService = staticWindowService;
        }

        private void Start()
        {
            Debug.Log($"Window Srvice HUD {_staticWindowService}");
            _staticWindowService.Open(StaticWindowId.HomeWindow);
        }
    }
}