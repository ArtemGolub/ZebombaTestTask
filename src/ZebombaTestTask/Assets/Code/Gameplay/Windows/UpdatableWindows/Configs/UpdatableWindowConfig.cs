using System;
using Code.Gameplay.Windows.StaticWindows;
using UnityEngine;

namespace Code.Gameplay.Windows.UpdatableWindows.Configs
{
    [Serializable]
    public class UpdatableWindowConfig
    {
        public UpdatableWindowId Id;
        public GameObject Prefab;
    }
}