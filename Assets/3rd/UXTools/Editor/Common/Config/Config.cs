using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
namespace ThunderFireUITool
{
    //UXTools中的路径和常量
    public partial class ThunderFireUIToolConfig
    {
        
        
        public static  string AssetsRootPath = Path.Combine(EditorLocalizationPath() + "/Res/");
        public static  string ToolsRootPath = Path.Combine(EditorLocalizationPath() + "/Editor/"); 

        public static string EditorLocalizationPath()
        {
            var config = AssetDatabase.FindAssets("t:ScriptableObject " + "UXBeginnerGuideSetting");
            if (config.Length == 0)
            {
                Debug.LogError("No ScriptableObject found with name: " + "UXBeginnerGuideSetting");
                return null;
            }
            
            var fullPath = AssetDatabase.GUIDToAssetPath(config[0]);

           
            
            // 找到最后一个斜杠的位置
            int lastSlashIndex = fullPath.LastIndexOf('/');

            // 提取出路径部分，去掉文件名
            string parentDirectory = fullPath.Substring(0, lastSlashIndex);
            
            return parentDirectory;
        }
        
    }
    
    
}
