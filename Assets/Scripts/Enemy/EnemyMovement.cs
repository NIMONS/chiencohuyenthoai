using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : CCHTMonoBehaviour
{
    [SerializeField] protected Transform targetPos;
    public Transform TargetPos => targetPos;
    [SerializeField] protected Transform attackPosition;
    public Transform AttackPosition => attackPosition;
    [SerializeField] protected float speedMove = 1f;

    protected override void Update()
    {
        base.Update();
        if (this.targetPos != null) this.MoveTowardsTarget();
        //this.CheckPosition();
    }

    protected void MoveTowardsTarget()
    {
        float step = speedMove * Time.deltaTime;
        transform.parent.position= Vector3.MoveTowards(transform.position, targetPos.position, step);
    }

    public void SetTarget(Transform target)
    {
        this.targetPos= target;
    }

    public void SetAttackPosition(Transform attackPos)
    {
        this.attackPosition= attackPos;
    }
}
