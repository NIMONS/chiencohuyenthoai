using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : MoveObjcet
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected Rigidbody2D _rigibody2D;
    [SerializeField] protected CircleCollider2D _circleCollider2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadRigidbody2D();
        this.LoadCircleCollider2D();
    }

    protected void LoadCircleCollider2D()
    {
        if (this._circleCollider2D != null) return;
        this._circleCollider2D = transform.GetComponent<CircleCollider2D>();
        Debug.LogWarning(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    protected void LoadRigidbody2D()
    {
        if (this._rigibody2D != null) return;
        this._rigibody2D = transform.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl=transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }
}
