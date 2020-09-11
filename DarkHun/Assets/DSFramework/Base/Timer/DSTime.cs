using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFramework {
    /// <summary>
    /// 时间类
    /// </summary>
    public class DSTime {
        #region 定时执行
        /// <summary>
        /// 多少秒后执行
        /// </summary>
        /// <param name="second"></param>
        /// <param name="fun"></param>
        public static void Timer(float second, Action fun) {
            DSMonoMgr.Instance.StartCoroutine(IETimer(second, fun));
        }
        private static IEnumerator IETimer(float second, Action fun) {
            yield return new WaitForSeconds(second);
            fun?.Invoke();
        }
        #endregion

    }

}