using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFramework {
    public class DelayPush : SimpleMonoBehaviour {
        private void OnEnable() {
            Invoke("Push", 4f);
        }

        private void Push() {
            DSPoolMgr.Instance.PushObj("Example/002缓存池/Cube", gameObject);
        }

    }
}
