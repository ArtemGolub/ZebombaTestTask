using Code.Gameplay.Windows;
using Code.Gameplay.Windows.StaticWindows;
using Code.Gameplay.Windows.UpdatableWindows;
using UnityEngine;

namespace Code.Gameplay.StaticData.WindowsStaticData
{
    public interface IWindowsStaticDataService
    {
        Awaitable LoadAll();
        GameObject GetStaticWindowPrefab(StaticWindowId id);
        GameObject GetUpdatableWindowPrefab(UpdatableWindowId id);
        GameObject GetCanvasPrefab();

    }
}