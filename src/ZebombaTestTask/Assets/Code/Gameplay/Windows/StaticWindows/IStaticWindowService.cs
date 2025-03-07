﻿namespace Code.Gameplay.Windows.StaticWindows
{
  public interface IStaticWindowService
  {
    void Open(StaticWindowId staticWindowId);
    void Close(StaticWindowId staticWindowId);
    void CloseAll();
  }
}