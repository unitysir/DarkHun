using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMonoBehaviour : MonoBehaviour
{
    /// <summary>
    /// 获取或者添加物体对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    protected T GetOrAddComponect<T>(GameObject go) where T : Component {
        T t = go.GetComponent<T>();
        if (t == null) {
            t = go.AddComponent<T>();
        }
        return t;
    }
}
