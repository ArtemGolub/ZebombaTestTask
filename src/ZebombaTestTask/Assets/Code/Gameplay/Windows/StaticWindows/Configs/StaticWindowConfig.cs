using System;
using UnityEngine;

namespace Code.Gameplay.Windows.StaticWindows.Configs
{
  [Serializable]
  public class StaticWindowConfig
  {
    public StaticWindowId Id;
    public GameObject Prefab;
  }
}