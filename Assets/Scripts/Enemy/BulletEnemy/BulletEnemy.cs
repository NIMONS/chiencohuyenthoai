using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletEnemy : CCHTMonoBehaviour
{
    [SerializeField] protected CircleCollider2D _circleCollider2D;
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    [SerializeField] protected float speedBullet = 10f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadCirclCollider2D();
        //this.LoadRigidbody2D();
    }
    protected void LoadRigidbody2D()
    {
        if (this._rigidbody2D == null) return;
        this._rigidbody2D = transform.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

    protected void LoadCirclCollider2D()
    {
        if (this._circleCollider2D == null) return;
        this._circleCollider2D = transform.GetComponent<CircleCollider2D>();
        Debug.LogWarning(transform.name + ": LoadCirclCollider2D", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        this.BulletEneMove();
    }

    protected void BulletEneMove()
    {
        transform.Translate(Vector3.down * this.speedBullet * Time.deltaTime);
    }
}
