/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年09月03日 17:32:27
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：面板基类
    ----------------------------
--------------------------------
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFramework {
    public class DSBasePanel : SimpleMonoBehaviour {
        /// <summary>
        /// 面板路径
        /// </summary>
        public string panelPath;

        /// <summary>
        /// 面板对象
        /// </summary>
        public GameObject panelObj;

        /// <summary>
        /// 面板层级
        /// </summary>
        public DSPanelMgr.Layer panelLayer = DSPanelMgr.Layer.Normal;

        /// <summary>
        /// 加载面板
        /// </summary>
        public void Load() {
            GameObject skinPrefab = Resources.Load<GameObject>(panelPath);
            panelObj = Instantiate(skinPrefab);

            Debug.Log("加载面板--Load()");
        }

        /// <summary>
        /// 关闭面板
        /// </summary>
        public void Close() {
            string name = GetType().ToString();
            DSPanelMgr.Instance.Close(name);

            Debug.Log("关闭面板--Close()");
        }

        /// <summary>
        /// 加载面板资源
        /// </summary>
        public virtual void OnLoad() {

            Debug.Log("加载面板资源--OnLoad()");
        }

        /// <summary>
        /// 初始化组件
        /// </summary>
        /// <param name="para"></param>
        public virtual void OnInitCmt(params object[] para) {

            Debug.Log("显示组件--OnShow()");
        }

        /// <summary>
        /// 异步操作
        /// </summary>
        public virtual void OnAction() {

            Debug.Log("添加组件事件--OnClick()");
        }

        /// <summary>
        /// 关闭组件
        /// </summary>
        public virtual void OnClose() {

            Debug.Log("关闭组件--OnClose()");
        }
    }
}
