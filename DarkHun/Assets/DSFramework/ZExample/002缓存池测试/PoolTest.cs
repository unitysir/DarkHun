using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace DSFramework {
    public class PoolTest : SimpleMonoBehaviour {
        // Start is called before the first frame update
        void Start() {
            //PoolMgr.Instance.GetObj("Example/002缓存池/Cube");
            //PoolMgr.Instance.GetObj("Example/002缓存池/Sphere");
            //PoolMgr.Instance.GetObj("Example/002缓存池/Capsule");

        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                DSPoolMgr.Instance.GetObj("Example/002缓存池/Cube");
            }
        }
    }
}
