/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年08月29日 15:35:26
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：唯一的 Update
    ----------------------------
--------------------------------
*****************************************************/

using System;
using UnityEngine;

public class MonoMgr : Single<MonoMgr> {
    private MonoCtrl monoCtrl;

    public MonoMgr() {
        GameObject mono = new GameObject("MonoCtrl");
        monoCtrl = mono.AddComponent<MonoCtrl>();
    }

    #region Update
    public void AddUpdate(Action fun) {
        monoCtrl.AddUpdate(fun);
    }

    public void DelUpdate(Action fun) {
        monoCtrl.DelUpdate(fun);
    }
    #endregion


    #region FixedUpdate
    public void AddFixedUpdate(Action fun) {
        monoCtrl.AddFixedUpdate(fun);
    }

    public void DelFixedUpdate(Action fun) {
        monoCtrl.DelFixedUpdate(fun);
    }
    #endregion

}
