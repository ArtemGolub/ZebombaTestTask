using UnityEngine;

namespace Code.Gameplay.Windows.StaticWindows
{
  public interface IStaticWindowFactory
  {
    public void SetUIRoot(RectTransform uiRoot);
    public StaticWindow CreateWindow(StaticWindowId staticWindowId);
  }
}