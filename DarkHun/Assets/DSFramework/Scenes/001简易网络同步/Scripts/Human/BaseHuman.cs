using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHuman : MonoBehaviour
{
    /// <summary>
    /// 是否移动
    /// </summary>
    protected bool isMoving = false;

    /// <summary>
    /// 移动目标点
    /// </summary>
    private Vector3 targetPosition;

    /// <summary>
    /// 移动速度
    /// </summary>
    public float speed =5f;

    /// <summary>
    /// 动画
    /// </summary>
    public Animator animator;

    /// <summary>
    /// 描述
    /// </summary>
    public string desc = "";

    /// <summary>
    /// 移动到某处
    /// </summary>
    /// <param name="pos"></param>
    public void MoveTo(Vector3 pos) {
        targetPosition = pos;
        isMoving = true;
        animator.SetFloat("forward", 2f);
    }


    public void MoveUpdate() {
        if (isMoving == false) return;

        Vector3 pos = transform.position;
        transform.position = Vector3.MoveTowards(pos, targetPosition, speed * Time.deltaTime);
        transform.LookAt(targetPosition);
        if (Vector3.Distance(pos, targetPosition) < 0.1f) {
            isMoving = false;
            animator.SetFloat("forward", 0f);
        }
    }

    protected void Start() {
        animator = transform.Find("ybot").GetComponent<Animator>();
    }

    protected void Update() {
        MoveUpdate();
    }

}
