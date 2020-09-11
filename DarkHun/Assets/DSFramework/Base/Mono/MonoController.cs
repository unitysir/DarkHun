/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年08月17日 14:59:26
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
using UnityEngine;

namespace DSFramework {
    public class MonoController : SimpleMonoBehaviour {
        private event Action updateAction;
        private event Action lateUpdateAction;
        private event Action fixedUpdateAction;

        private void Start() {
            DontDestroyOnLoad(this);
        }

        #region Update
        public void AddUpdateListener(Action fun) {
            updateAction += fun;
        }

        public void DelUpdateListener(Action fun) {
            updateAction -= fun;
        }
        #endregion

        #region LateUpdate
        public void AddLateUpdateListener(Action fun) {
            lateUpdateAction += fun;
        }

        public void DelLateUpdateListener(Action fun) {
            lateUpdateAction -= fun;
        }
        #endregion

        #region FixedUpdate
        public void AddFixedUpdateListener(Action fun) {
            fixedUpdateAction += fun;
        }

        public void DelFixedUpdateListener(Action fun) {
            fixedUpdateAction -= fun;
        }
        #endregion

        private void Update() {
            updateAction?.Invoke();
        }

        private void LateUpdate() {
            lateUpdateAction?.Invoke();
        }

        private void FixedUpdate() {
            fixedUpdateAction?.Invoke();
        }

    }
}