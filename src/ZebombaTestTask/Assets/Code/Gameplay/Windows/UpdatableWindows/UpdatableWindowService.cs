using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Windows.UpdatableWindows
{
    public class UpdatableWindowService: IUpdatableWindowService
    {
        private readonly IUpdatableWindowFactory _updatableWindowFactory;

        private readonly List<UpdatableWindow> _openedWindows = new();

        public UpdatableWindowService(IUpdatableWindowFactory updatableWindowFactory) =>
            _updatableWindowFactory = updatableWindowFactory;

        public void Open(UpdatableWindowId staticWindowId) => 
            _openedWindows.Add(_updatableWindowFactory.CreateWindow(staticWindowId));

        public void Close(UpdatableWindowId staticWindowId)
        {
            UpdatableWindow window = _openedWindows.Find(x => x.Id == staticWindowId);
      
            _openedWindows.Remove(window);
      
            GameObject.Destroy(window.gameObject);
        }
        
        public void CloseAll()
        {
            List<UpdatableWindow> windowsCopy = new List<UpdatableWindow>(_openedWindows);
     
            foreach (UpdatableWindow window in windowsCopy)
            {
                if (window != null && window.gameObject != null)
                {
                    GameObject.Destroy(window.gameObject);
                }
            }
            windowsCopy.Clear();
            _openedWindows.Clear();
        }
    }
}