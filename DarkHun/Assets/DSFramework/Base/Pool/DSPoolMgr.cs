using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFramework {
    public class DSPoolMgr : DSingle<DSPoolMgr> {

        private Dictionary<string, List<GameObject>> poolDic = new Dictionary<string, List<GameObject>>();

        private GameObject poolObj;//缓存池对象

        public DSPoolMgr() {
            poolObj = new GameObject("Pool");
        }

        /// <summary>
        /// 获取缓存池对象
        /// </summary>
        /// <returns></returns>
        public GameObject GetObj(string poolName) {
            GameObject obj = null;//缓存对象
            //如果当前缓存池中有需要的对象时,直接获取
            if (poolDic.ContainsKey(poolName)) {
                if (poolDic[poolName].Count > 0) {
                    obj = poolDic[poolName][0];
                    poolDic[poolName].RemoveAt(0);
                    obj.SetActive(true);
                    obj.transform.parent = null;

                }
            } else {//如果没有缓存池没有对象,则加载
                try {
                    obj = Object.Instantiate(Resources.Load<GameObject>(poolName));
                    obj.transform.parent = null;
                } catch {
                    throw new System.ArgumentException($"没有找到该资源:{poolName}", "objName");
                }
            }
            
            return obj;
        }

        /// <summary>
        /// 缓存对象
        /// </summary>
        /// <param name="objName"></param>
        public void PushObj(string objName, GameObject obj) {
            obj.SetActive(false);
            obj.transform.parent = poolObj.transform;
            if (poolDic.ContainsKey(objName)) {
                poolDic[objName].Add(obj);
            } else {
                poolDic.Add(objName, new List<GameObject> { obj });
            }
        }

        /// <summary>
        /// 清空缓存池
        /// </summary>
        public void ClearPool() {
            poolDic.Clear();
        }

    }
}
