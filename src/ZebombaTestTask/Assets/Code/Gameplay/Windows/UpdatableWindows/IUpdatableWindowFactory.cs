using UnityEngine;

namespace Code.Gameplay.Windows.UpdatableWindows
{
    public interface IUpdatableWindowFactory
    {
        public UpdatableWindow CreateWindow(UpdatableWindowId updatableWindowId);
        void SetUiRoot(GameObject uiRoot);
    }
}