using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundSensor : MonoBehaviour {
    public CapsuleCollider capsul;
    public float offset = 0.1f;

    private Vector3 point1;
    private Vector3 point2;

    private float radius;

    private void Awake() {
        radius = capsul.radius - 0.05f;



    }

    private void FixedUpdate() {

        point1 = transform.position + transform.up * (radius - offset);
        point2 = transform.position + transform.up * (capsul.height - 0.1f) - transform.up * radius;
        Collider[] colliders = Physics.OverlapCapsule(point1, point2, radius, LayerMask.GetMask("Ground"));
        if (colliders.Length != 0) {
            //foreach (var item in colliders) {
            //    print("collision" +item.gameObject.name);
            //}

            SendMessageUpwards("IsGround", true);

        } else {
            SendMessageUpwards("IsNotGround", false);
        }
    }

}
