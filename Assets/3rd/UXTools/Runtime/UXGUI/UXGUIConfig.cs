using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum LocalizationTypeDef
{
    zhCN = 0,
    zhTW = 1,
    enUS = 2,
    deDE = 3,
    jaJP = 4,
    koKR = 5,
    frFR = 6,
    esES = 7,
    ptPT = 8,
    ruRU = 9,
    trTR = 10,
    viVN = 11,
    arSA = 12,
    thTH = 13,
    idID = 14,
}

public class UXGUIConfig : ScriptableObject
{
    public static readonly string RootPath = "Assets/UXTools/Res/";
    public static readonly string GUIPath = RootPath + "UX-GUI/";

    public static readonly string UXImageDefaultMatPath = GUIPath + "Resources/Materials/UXImage.mat";
    public static readonly string UXTextDefaultMatPath = GUIPath + "Resources/Materials/UXImage.mat";
    public static readonly string UXGUINeedReplaceSpritePathReplace = GUIPath + "Resources/Materials/need_replace.png";

    public static readonly string ThaiWordDictPath = GUIPath + "Resources/thai_dict";

    public static readonly string UIBeginnerGuideResPath = "Assets/Res/UI/Prefab/BeginnerGuide/";

    // Localization
    public static bool enableLocalization = false;
    public static LocalizationTypeDef CurLocalizationType = LocalizationTypeDef.zhCN;
    // UIStateAnimator
    public static bool EnableOptimizeUIStateAnimator = true;

    [SerializeField]
    private List<int> m_AvailableLanguages;
    public static List<int> availableLanguages
    {
        get
        {
            var uxConfig = ResourceManager.Load<UXGUIConfig>("UXGUIConfig");
            return uxConfig.m_AvailableLanguages;
        }
    }
    [SerializeField]
    private string m_LocalizationFolder;
    public static string LocalizationFolder
    {
        get
        {
            var uxConfig = ResourceManager.Load<UXGUIConfig>("UXGUIConfig");
            return uxConfig.m_LocalizationFolder;
        }
#if UNITY_EDITOR
        set
        {
            var uxConfig = ResourceManager.Load<UXGUIConfig>("UXGUIConfig");
            uxConfig.m_LocalizationFolder = value;
            EditorUtility.SetDirty(uxConfig);
            AssetDatabase.SaveAssets();
        }
#endif
    }
    [SerializeField]
    private string m_PreviewTablePath;
    public static string PreviewTablePath
    {
        get
        {
            var uxConfig = ResourceManager.Load<UXGUIConfig>("UXGUIConfig");
            return uxConfig.m_PreviewTablePath;
        }
#if UNITY_EDITOR
        set
        {
            var uxConfig = ResourceManager.Load<UXGUIConfig>("UXGUIConfig");
            uxConfig.m_PreviewTablePath = value;
            EditorUtility.SetDirty(uxConfig);
            AssetDatabase.SaveAssets();
        }
#endif
    }

    [SerializeField]
    private string m_RuntimeTablePath;
    public static string RuntimeTablePath
    {
        get
        {
            var uxConfig = ResourceManager.Load<UXGUIConfig>("UXGUIConfig");
            return uxConfig.m_RuntimeTablePath;
        }
#if UNITY_EDITOR
        set
        {
            var uxConfig = ResourceManager.Load<UXGUIConfig>("UXGUIConfig");
            uxConfig.m_RuntimeTablePath = value;
            EditorUtility.SetDirty(uxConfig);
            AssetDatabase.SaveAssets();
        }
#endif
    }
    public static string TextLocalizationJsonPath
    {
        get
        {
            return UXGUIConfig.LocalizationFolder + "TextLocalization.json";
        }
    }
}