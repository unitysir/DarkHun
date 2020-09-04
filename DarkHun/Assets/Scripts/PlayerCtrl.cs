/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年08月29日 11:17:43
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：角色控制
    ----------------------------
--------------------------------
*****************************************************/
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    public GameObject playeModel;
    public float walkSpeed = 1.4f;
    public float runSpeed = 2.7f;

    private PlayerInput pi;
    private Animator animator;
    private Rigidbody rigi;
    /// <summary>
    /// 移动的方向
    /// </summary>
    private Vector3 movingVec;

    private void Awake() {
        pi = GetComponent<PlayerInput>();
        animator = playeModel.GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();
    }

    private void Start() {
        MonoMgr.Instance.AddUpdate(OnUpdate);
        MonoMgr.Instance.AddFixedUpdate(OnFixedUpdate);
    }

    private void OnUpdate() {
        //设置角色移动的动画
        animator.SetFloat("forward", pi.Dmag * Mathf.Lerp(animator.GetFloat("forward"), (pi.isRun ? 2f : 1f), 0.5f));

        if (pi.jump) {
            animator.SetTrigger("jump");
        }
        //设置角色移动的方向
        if (pi.Dmag > 0.1f) { // 当角色动画中的数值大于 0.1时 才让角色进行旋转
            playeModel.transform.forward = Vector3.Slerp(playeModel.transform.forward, pi.Dvec, 0.3f);
        }
        movingVec = pi.Dmag * playeModel.transform.forward * walkSpeed * (pi.isRun ? runSpeed : 1f);
    }

    private void OnFixedUpdate() {
        //rigi.position += movingVec * Time.fixedDeltaTime;
        rigi.velocity = new Vector3(movingVec.x, rigi.velocity.y, movingVec.z);
    }
}
