using System;
using Code.Infrastructure.AssetManagement.Constants;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Build.DataBuilders;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;

namespace Editor.BuildScripts
{
    [CreateAssetMenu(fileName = "MarkRemoteGroupsBuildScriptPacked.asset", menuName = "Addressables/Mark Remote Groups Build Script")]
    public class MarkRemoteGroupsBuildScript: BuildScriptPackedMode
    {
        public override string Name => "Mark Remote Groups Build Script";
        private static AddressableAssetSettings Settings => AddressableAssetSettingsDefaultObject.Settings;

        protected override TResult BuildDataImplementation<TResult>(AddressablesDataBuilderInput builderInput)
        {
            TResult result = base.BuildDataImplementation<TResult>(builderInput);

            MarkRemoteAssetsInGroups();
            
            return result;
        }

        private void MarkRemoteAssetsInGroups()
        {
            AddRemoteLabelIfNeeded();
            foreach (AddressableAssetGroup group in Settings.groups)
            {
                foreach (AddressableAssetEntry entry in group.entries)
                    entry.SetLabel(DownloadServiceConstants.RemoteLabel, group.IsRemote());

                SetTimeoutForRemoteGroup(group);
                
                EditorUtility.SetDirty(group);
            }
        }

        private void SetTimeoutForRemoteGroup(AddressableAssetGroup group)
        {
            if (group.IsRemote())
                group.GetSchema<BundledAssetGroupSchema>().Timeout = (int) TimeSpan.FromMinutes(1).TotalSeconds;
        }

        private static void AddRemoteLabelIfNeeded()
        {
            if (!Settings.GetLabels().Contains(DownloadServiceConstants.RemoteLabel) && !Settings.GetLabels().Contains(DownloadServiceConstants.LocalLabel))
                Settings.AddLabel(DownloadServiceConstants.RemoteLabel);
        }        
    }
}