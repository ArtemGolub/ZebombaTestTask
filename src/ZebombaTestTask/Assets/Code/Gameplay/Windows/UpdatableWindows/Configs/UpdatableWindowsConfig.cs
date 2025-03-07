using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.Windows.UpdatableWindows.Configs
{
    [CreateAssetMenu(fileName = "windowConfig", menuName = "UI/Updatable Window Config")]
    public class UpdatableWindowsConfig: ScriptableObject
    {
        public GameObject canvasPrefab;
        public List<UpdatableWindowConfig> windowConfigs;
    }
}