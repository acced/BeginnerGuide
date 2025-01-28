#if UNITY_EDITOR && ODIN_INSPECTOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ThunderFireUITool
{
    public class UIAtlasCheckRuleSettings : ScriptableObject
    {
        [MenuItem(ThunderFireUIToolConfig.Menu_CreateAssets + "/" + ThunderFireUIToolConfig.ResourceCheck + "/UIResCheckSetting", false, -1)]
        public static UIAtlasCheckRuleSettings Create()
        {
            var settings = CreateInstance<UIAtlasCheckRuleSettings>();
            if (settings == null)
                Debug.LogError("Create UIAtlasCheckRuleSettings Failed!");

            string path = Path.GetDirectoryName(ThunderFireUIToolConfig.UICheckSettingFullPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var assetPath = ThunderFireUIToolConfig.UICheckSettingFullPath;
            AssetDatabase.CreateAsset(settings, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return settings;
        }

        public string imageFolderPath = "Assets/Artist/UI/BigImages";
        public string atlasFolderPath = "Assets/Prefabs/Atlas";
        public string prefabFolderPath = "Assets/Prefabs/UI";
        public string animFolderPath = "Assets/Artist/AnimationClip";
        public string defaultFontPath = "Assets/Res/GUI/Fonts/Default.otf";

        public int atlasLimit = 4;
        public int imageLimit = 13;

        public void Save(int newAtlasLimit, int newImageLimit, string newImagePath, string newAtlasPath, string newPrefabPath, string newAnimPath, string newFontPath)
        {
            atlasLimit = newAtlasLimit;
            imageLimit = newImageLimit;

            imageFolderPath = newImagePath;
            atlasFolderPath = newAtlasPath;
            prefabFolderPath = newPrefabPath;
            animFolderPath = newAnimPath;
            defaultFontPath = newFontPath;

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
#endif