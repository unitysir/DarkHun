/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年08月17日 14:59:38
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：
    ----------------------------
--------------------------------
*****************************************************/

using System;
using System.Collections;
using UnityEngine;

namespace DSFramework {
    public class DSMonoMgr : DSingle<DSMonoMgr> {
        private MonoController controller;

        public DSMonoMgr() {
            GameObject obj = new GameObject("MonoCtrl");
            controller = obj.AddComponent<MonoController>();
        }

        #region Update
        public void AddUpdateListener(Action fun) {
            controller.AddUpdateListener(fun);
        }

        public void DelUpdateListener(Action fun) {
            controller.DelUpdateListener(fun);
        }
        #endregion

        #region LateUpdate
        public void AddLateUpdateListener(Action fun) {
            controller.AddLateUpdateListener(fun);
        }

        public void DelLateUpdateListener(Action fun) {
            controller.DelLateUpdateListener(fun);
        }
        #endregion

        #region FixedUpdate
        public void AddFixedUpdateListener(Action fun) {
            controller.AddFixedUpdateListener(fun);
        }

        public void DelFixedUpdateListener(Action fun) {
            controller.DelFixedUpdateListener(fun);
        }
        #endregion



        public Coroutine StartCoroutine(IEnumerator routine) {
            return controller.StartCoroutine(routine);
        }

    }
}