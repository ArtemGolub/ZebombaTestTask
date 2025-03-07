using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class BundleCacheCleaner
    {
        [MenuItem("Tools/Clear Addresable bundles cache")]
        private static void ClearBundleCache()
        {
            Caching.ClearCache();
        }
    }
}