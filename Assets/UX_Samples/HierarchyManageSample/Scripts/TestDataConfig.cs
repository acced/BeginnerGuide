#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestDataConfig : ScriptableObject
{
    // [MenuItem("Assets/Test Data Config")]
    public static void Create()
    {
        TestDataConfig setting = ScriptableObject.CreateInstance<TestDataConfig>();
        AssetDatabase.CreateAsset(setting, "Assets/UX_Samples/HierarchyManageSample/Resources/TestDataConfig.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    public List<TestPrefabHierarchyData> guidList = new List<TestPrefabHierarchyData>();
}


[Serializable]
public class TestPrefabHierarchyData
{
    public string Name;
    public string Channel;
    public int Level;
    public string Guid;
}
#endif