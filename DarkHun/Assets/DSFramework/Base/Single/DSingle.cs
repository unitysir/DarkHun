/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年09月03日 17:31:17
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：泛型单例
    ----------------------------
--------------------------------
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFramework {
    public class DSingle<T> where T : new() {
        private static T instance;

        public static T Instance {
            get { if (instance == null) instance = new T(); return instance; }
        }

    }
}
