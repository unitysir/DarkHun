using System;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace DSFramework {

    public class ExporterUtil {
        public static string GeneratePackageName() {
            return "DSFramework_" + DateTime.Now.ToString("yyyy-MM-dd__HH_mm_ss");
        }

    #if UNITY_EDITOR

        [MenuItem("DSFramework/01.导出 Unity Package %e", false, 1)]
        static void MenuClicked() {
            EditorUtil.ExportPackage("Assets/DSFramework",
                                     GeneratePackageName() + ".unitypackage");
            EditorUtil.OpenFile(Path.Combine(Application.dataPath, "../"));
        }
    #endif
    }
}