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
using DSFramework;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    public GameObject playeModel;
    public float walkSpeed = 1.4f;
    public float runSpeed = 2.7f;
    public float jumpThrust = 3f;

    private PlayerInput pi;
    private Animator animator;
    private Rigidbody rigi;
    /// <summary>
    /// 移动的方向
    /// </summary>
    private Vector3 planarVec;
    /// <summary>
    /// 冲量
    /// </summary>
    private Vector3 thrustVel;
    /// <summary>
    /// 是否锁定移动
    /// </summary>
    private bool lockplanar = false;

    private void Awake() {
        pi = GetComponent<PlayerInput>();
        animator = playeModel.GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();
    }

    private void Start() {
        DSMonoMgr.Instance.AddUpdateListener(OnUpdate);
        DSMonoMgr.Instance.AddFixedUpdateListener(OnFixedUpdate);
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
        // 不锁定移动 ， 反之锁定
        if (lockplanar==false) {
            planarVec = pi.Dmag * playeModel.transform.forward * walkSpeed * (pi.isRun ? runSpeed : 1f);
        }
    }

    private void OnFixedUpdate() {
        //rigi.position += movingVec * Time.fixedDeltaTime;
        rigi.velocity = new Vector3(planarVec.x, rigi.velocity.y, planarVec.z) + thrustVel;
        thrustVel = Vector3.zero;
    }




    ///////////////////////////////////////

    public void IsGround() {
        animator.SetBool("isGround", true);
    }

    public void IsNotGround() {
        animator.SetBool("isGround", false);
    }



    public void OnJumpEnter() {
        pi.inputEnable = false;
        lockplanar = true;
        thrustVel = new Vector3(0, jumpThrust, 0);
    }

    public void OnGroundEnter() {
        pi.inputEnable = true;
        lockplanar = false;
    }

}
