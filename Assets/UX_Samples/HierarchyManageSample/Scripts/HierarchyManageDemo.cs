#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class HierarchyManageDemo : MonoBehaviour
{
    void Start()
    {
        Init();
    }

    private void Init()
    {
        var testDataConfig = ResourceManager.Load<TestDataConfig>(
            "Assets/UX_Samples/HierarchyManageSample/Resources/TestDataConfig.asset");
        var list = testDataConfig.guidList;
        list.Sort((x, y) => x.Level.CompareTo(y.Level));
        var canvasPrefab =
            ResourceManager.Load<GameObject>("Assets/UX_Samples/HierarchyManageSample/Resources/Prefabs/Canvas.prefab");
        var canvas = Instantiate(canvasPrefab);
        DontDestroyOnLoad(canvas);
        foreach (var item in list)
        {
            var guid = item.Guid;
            var prefab = ResourceManager.Load<GameObject>(AssetDatabase.GUIDToAssetPath(guid));
            var go = Instantiate(prefab, canvas.transform);
        }
    }
}
#endif