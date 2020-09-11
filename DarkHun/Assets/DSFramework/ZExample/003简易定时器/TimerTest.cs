using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFramework {
    public class TimerTest : MonoBehaviour {
        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            DSTime.Timer(5f, () => { Debug.Log("延时五秒。。。"); });
        }
    }
}
