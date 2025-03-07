using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Build.AnalyzeRules;
using UnityEditor.AddressableAssets.Settings;

namespace Editor.CustomAnalyseRules
{
    public class SceneToAssetNoUnityBuildInAnalyseRule: CheckSceneDupeDependencies
    {
        public override string ruleName => "Scene To Addressable No Unity BuildIn";

        public override List<AnalyzeResult> RefreshAnalysis(AddressableAssetSettings settings)
        {
            List<AnalyzeResult> result = base.RefreshAnalysis(settings)
                .Where(x => !x.resultName.Contains("unity_builtin_extra"))
                .ToList();
            
            return result;
        }
    }

    [InitializeOnLoad]
    class  RegisterSceneToAssetNoUnityBuildInAnalyseRule
    {
        static RegisterSceneToAssetNoUnityBuildInAnalyseRule()
        {
            AnalyzeSystem.RegisterNewRule<SceneToAssetNoUnityBuildInAnalyseRule>();
        }
    }
    
}