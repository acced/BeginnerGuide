using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ThunderFireUITool
{
    //UXTools中的路径和常量
    public partial class ThunderFireUIToolConfig
    {
        public static readonly string RootPath = "Assets/";

        public static readonly string SamplesRootPath = "Assets/UX_Samples/";

        public static readonly string AssetsRootPath = "Assets/UXTools/Res/";
        public static readonly string ToolsRootPath = "Assets/UXTools/Editor/";

        public static readonly string AutoAssembleToolZipPath = "Assets/UXTools/3rdTools/AutoAssembleTool.zip";
        public static readonly string AutoAssembleToolPath = "Assets/UXTools/3rdTools/AutoAssembleTool.exe";

        //L22
        //public static readonly string RootPath = "Assets/Editor/editor_ui/UXTools/Res/";

        //L33
        //public static readonly string RootPath = "";

        //Quick Create
        public static readonly string TextAssemblyName = "Leihuo.UXTools.Runtime";
        public static readonly string TextClassName = "UnityEngine.UI.UXText";
        public static readonly string ImageAssemblyName = "Leihuo.UXTools.Runtime";
        public static readonly string ImageClassName = "UnityEngine.UI.UXImage";

        //L33
        //public static readonly string TextAssemblyName = "UnityEngine.UI";
        //public static readonly string TextClassName = "UnityEngine.UI.Text";
        //public static readonly string ImageAssemblyName = "Assembly-CSharp";
        //public static readonly string ImageClassName = "UnityEngine.UI.UIImage";
    }
}
