/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年09月03日 17:31:46
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
using UnityEngine.UI;

namespace DSFramework {
    public class PanelTest : DSBasePanel {
        private Text txt;
        private Button btn;

        public override void OnLoad() {
            base.OnLoad();
            panelPath = "Example/001打开面板/PanelTest";
            panelLayer = DSPanelMgr.Layer.Normal;
        }

        public override void OnInitCmt(params object[] para) {
            base.OnInitCmt(para);
            txt = panelObj.transform.Find("Text").GetComponent<Text>();
            btn = panelObj.transform.Find("Button").GetComponent<Button>();
        }

        public override void OnAction() {
            base.OnAction();
            btn.onClick.AddListener(() => {
                txt.text = "Hello,World!";
            });
        }

        public override void OnClose() {
            base.OnClose();
        }
    }
}
