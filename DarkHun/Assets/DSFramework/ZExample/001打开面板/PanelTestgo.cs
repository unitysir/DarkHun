/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年09月03日 17:31:25
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFramework {
    public class PanelTestgo : SimpleMonoBehaviour {
        // Start is called before the first frame update
        void Start() {
            DSPanelMgr.Instance.Open<PanelTest>();
        }

        // Update is called once per frame
        void Update() {

        }
    }
}
