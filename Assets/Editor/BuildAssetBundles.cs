// Create an AssetBundle for Windows.
using UnityEngine;
using UnityEditor;

public class BuildAssetBundles : MonoBehaviour
{
    [MenuItem("Example/Build Asset Bundles")]
    static void BuildABs()
    {
        // Put the bundles in a folder called "ABs" within the Assets folder.
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}