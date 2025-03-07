using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Windows.StaticWindows.Configs
{
  [CreateAssetMenu(fileName = "windowConfig", menuName = "UI/Static Window Config")]
  public class StaticWindowsConfig : ScriptableObject
  {
    public List<StaticWindowConfig> WindowConfigs;
  }
}