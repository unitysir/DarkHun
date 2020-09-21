#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.IO;
using UnityEngine;

namespace DSFramework {

    public partial class EditorUtil {
    #if UNITY_EDITOR
        public static void OpenFile(string filepath) { Application.OpenURL("file:///" + filepath); }

        //public static void CallMenuItem(string menuName) {
        //    //EditorApplication.ExecuteMenuItem(menuName);
        //    Application.OpenURL("file://" + Path.Combine(Application.dataPath, "../"));
        //}

        public static void CallMenuItem() {
            Application.OpenURL("file://" + Path.Combine(Application.dataPath, "../"));
        }

        public static void ExportPackage(string assetName, string fileName) {
            AssetDatabase.ExportPackage(assetName, fileName, ExportPackageOptions.Recurse);
        }

        [MenuItem("DSFramework/03.打开文件所在位置", false, 3)]
        private static void MenuClicked() { EditorUtil.CallMenuItem(); }

    #endif
    }

}