/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年08月29日 15:34:59
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

public class MonoCtrl : MonoBehaviour
{
    private event Action updateAction;
    private event Action fixedUpdateAction;

    private void Start() {
        DontDestroyOnLoad(this);
    }


    void Update()
    {
        updateAction?.Invoke();
    }

    private void FixedUpdate() {
        fixedUpdateAction?.Invoke();
    }

    #region Update
    public void AddUpdate(Action fun) {
        fixedUpdateAction += fun;
    }

    public void DelUpdate(Action fun) {
        fixedUpdateAction -= fun;
    }
    #endregion

    #region FixedUpdate
    public void AddFixedUpdate(Action fun) {
        updateAction += fun;
    }

    public void DelFixedUpdate(Action fun) {
        updateAction -= fun;
    }
    #endregion

}
