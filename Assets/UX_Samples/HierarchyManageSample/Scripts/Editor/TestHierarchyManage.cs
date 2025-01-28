#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using ThunderFireUITool;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class TestHierarchyManage : ScriptableObject
{
    [MenuItem("Assets/打开层级管理工具Demo (Open Hierarchy Manage Demo)", false, -799)]
    public static void SelectedGameObject()
    {
        InitSampleData();
        HierarchyManagementWindow.OpenWindow(true, HierarchyManageDataConvertToSampleData);
    }

    [MenuItem("Assets/打开层级管理工具Demo (Open Hierarchy Manage Demo)", true)]
    private static bool CheckObjectType()
    {
        Object selectedObject = Selection.activeObject;
        if (selectedObject != null && selectedObject.name == "TestDataConfig")
            return true;
        return false;
    }

    private static void InitSampleData()
    {
        //Sample的配置文件
        HierarchyManagementSetting setting = JsonAssetManager.LoadAssetAtPath<HierarchyManagementSetting>(ThunderFireUIToolConfig.HierarchyManagementSettingPath_Sample);
        if (setting == null)
        {
            setting = JsonAssetManager.CreateAssets<HierarchyManagementSetting>(ThunderFireUIToolConfig.HierarchyManagementSettingPath_Sample);
            HierarchyManagementSetting.InitDefault(setting);
            JsonAssetManager.SaveAssetsAtPath(setting, ThunderFireUIToolConfig.HierarchyManagementSettingPath_Sample);
        }

        //Sample的PrefabEditorData
        HierarchyManagementEditorData editorData = JsonAssetManager.LoadAssetAtPath<HierarchyManagementEditorData>(ThunderFireUIToolConfig.HierarchyManagementEditorDataPath_Sample);
        if (editorData == null)
        {
            editorData = JsonAssetManager.CreateAssets<HierarchyManagementEditorData>(ThunderFireUIToolConfig.HierarchyManagementEditorDataPath_Sample);
            JsonAssetManager.SaveAssetsAtPath(editorData, ThunderFireUIToolConfig.HierarchyManagementEditorDataPath_Sample);
        }

        //Sample的PrefabData
        //Sample中使用TestDataConfig.asset作为运行时实际读取的数据格式,这里加载只是用作实例
        HierarchyManagementData data = JsonAssetManager.LoadAssetAtPath<HierarchyManagementData>(ThunderFireUIToolConfig.HierarchyManagementDataPath_Sample);
        if (data == null)
        {
            data = JsonAssetManager.CreateAssets<HierarchyManagementData>(ThunderFireUIToolConfig.HierarchyManagementDataPath_Sample);
            JsonAssetManager.SaveAssetsAtPath(data, ThunderFireUIToolConfig.HierarchyManagementDataPath_Sample);
        }
    }

    private static void HierarchyManageDataConvertToSampleData()
    {
        // HierarchyManageSample中使用ScriptableObject作为运行时实际读取的数据格式
        // 用户可以根据项目实际情况自行决定使用哪种数据格式, 也可以直接使用HierarchyManagementData提供的Json格式

        var testDataConfig = AssetDatabase.LoadAssetAtPath<TestDataConfig>(
            "Assets/UX_Samples/HierarchyManageSample/Resources/TestDataConfig.asset");

        testDataConfig.guidList.Clear();
        foreach (var item in HierarchyManagementEvent._prefabDetails)
        {
            testDataConfig.guidList.Add(new TestPrefabHierarchyData()
            {
                Guid = item.Guid,
                Name = item.Name,
                Channel = HierarchyManagementEvent._managementChannels.Where(t => t.ID == item.ChannelID).FirstOrDefault().Name,
                Level = HierarchyManagementEvent._managementLevels.Where(t => t.ID == item.LevelID).FirstOrDefault().Index,
            });
        }

        testDataConfig.guidList.Sort((x, y) =>
        {
            return x.Level == y.Level
                ? testDataConfig.guidList.IndexOf(x).CompareTo(testDataConfig.guidList.IndexOf(y))
                : x.Level.CompareTo(y.Level);
        });
        EditorUtility.SetDirty(testDataConfig);
        AssetDatabase.SaveAssets();
    }
}
#endif