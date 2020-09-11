/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年09月03日 17:31:56
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：面板管理器，用于打开或者关闭面板
    ----------------------------
--------------------------------
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFramework {
    public class DSPanelMgr : DSingle<DSPanelMgr> {


        public DSPanelMgr() {
            Init();
        }

        /// <summary>
        /// 层级
        /// </summary>
        public enum Layer {
            Background, Normal, Tip,
        }

        /// <summary>
        /// 层级字典
        /// </summary>
        private Dictionary<Layer, Transform> layerDic = new Dictionary<Layer, Transform>();

        /// <summary>
        /// 面板字典
        /// </summary>
        private Dictionary<string, DSBasePanel> panelDic = new Dictionary<string, DSBasePanel>();

        private Transform m_UIRoot;
        private Transform m_Canvas;

        private void Init() {
            m_UIRoot = GameObject.FindWithTag("UIRoot").transform;
            m_Canvas = m_UIRoot.Find("Canvas");

            layerDic.Add(Layer.Background, m_Canvas.Find("Background"));
            layerDic.Add(Layer.Normal, m_Canvas.Find("Normal"));
            layerDic.Add(Layer.Tip, m_Canvas.Find("Tip"));
        }

        public void Open<T>(params object[] para) where T : DSBasePanel {
            //面板已经打开时
            string name = typeof(T).ToString();
            if (panelDic.ContainsKey(name)) {
                return;
            }

            DSBasePanel panel = m_UIRoot.gameObject.AddComponent<T>();
            panel.OnLoad();
            panel.Load();

            Transform parent = layerDic[panel.panelLayer];
            panel.panelObj.transform.SetParent(parent, false);

            panelDic.Add(name, panel);
            panel.OnInitCmt();
            panel.OnAction();

        }

        public void Close(string name) {
            //面板没有打开时
            if (!panelDic.ContainsKey(name)) {
                return;
            }

            DSBasePanel panel = panelDic[name];
            panel.OnClose();
            panelDic.Remove(name);
            Object.Destroy(panel.panelObj);
            Object.Destroy(panel);

        }

    }
}