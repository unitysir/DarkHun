/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年08月29日 11:17:32
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：输入检测
    ----------------------------
--------------------------------
*****************************************************/
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    #region Definition
    [Header("== Key Setting ==")]
    #region public
    // 控制方向
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyDown = KeyCode.S;
    public KeyCode keyLeft = KeyCode.A;
    public KeyCode keyRight = KeyCode.D;

    //技能键
    /// <summary>
    /// 跑步
    /// </summary>
    public KeyCode keyA = KeyCode.LeftShift;
    /// <summary>
    /// 跳跃
    /// </summary>
    public KeyCode keyB = KeyCode.Space;
    public KeyCode keyC;
    public KeyCode keyD;

    [Header("== OutPut Signals ==")]
    // 当前转向信号
    public float Dup;
    public float Dright;

    /// <summary>
    /// 设置角色移动的动画
    /// </summary>
    public float Dmag;
    /// <summary>
    /// 设置角色的朝向
    /// </summary>
    public Vector3 Dvec;

    // ctrl
    public bool isRun;
    public bool jump;
    private bool lastJump;

    [Header("== Others ==")]
    //输入开关
    public bool inputEnable = true;

    #endregion

    #region private

    //转向目标的信号,使用 SmoothDamp()
    private float targetDup;
    private float targetDright;
    private float velocityDup;
    private float velocityDright;

    #endregion

    #endregion

    private void Start() {
        MonoMgr.Instance.AddUpdate(OnUpdate);
    }

    private void OnUpdate() {
        //增加输入开关
        if (!inputEnable) return;

        #region 通过键盘输入获取上下左右的方向

        // 目标朝向
        targetDup = (Input.GetKey(keyUp) ? 1f : 0f) - (Input.GetKey(keyDown) ? 1.0f : 0f);
        targetDright = (Input.GetKey(keyRight) ? 1f : 0f) - (Input.GetKey(keyLeft) ? 1.0f : 0f);

        //前进、后退
        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        //向左、向右
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

        Vector2 tempAxis = SquareToCircle(new Vector2(Dright, Dup));
        float Dright2 = tempAxis.x;
        float Dup2 = tempAxis.y;

        //设置角色移动的动画(0:站立，1:走路)
        Dmag = Mathf.Sqrt((Dup2 * Dup2) + (Dright2 * Dright2));
        //设置角色的朝向
        Dvec = Dright2 * transform.right + Dup2 * transform.forward;
        #endregion

        //跑步
        isRun = Input.GetKey(keyA);
        //跳跃
        bool newJump = Input.GetKey(keyB);
        // lastJump 初始值为 false ，如果 new不等于last  则 new=true
        if (newJump != lastJump && newJump == true) {
            jump = true;
        } else {
            jump = false;
        }
        lastJump = newJump;
    }

    /// <summary>
    /// 方形坐标转圆形坐标
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private Vector2 SquareToCircle(Vector2 input) {
        Vector2 output = Vector2.zero;

        // 根据公式
        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y / 2));
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x / 2));

        return output;
    }
}
