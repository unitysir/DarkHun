/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年09月13日 18:50:54
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：批量导入
    ----------------------------
--------------------------------
*****************************************************/

#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;


public class BatchImport {
    public static string mPath = Application.dataPath;

    [MenuItem("DSFramework/02.批量导入资源包", false, 2)]
    static void BatchImporter() {
        try {
            mPath = EditorUtility.OpenFolderPanel("选择批量导入文件夹", mPath, "");
            string[] files = Directory.GetFiles(mPath);
            foreach (string file in files)
                if (file.EndsWith(".unitypackage"))
                    AssetDatabase.ImportPackage(file, false);
        } catch {
        }
    }
}
#endif
