using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : DestroyByDistance
{
    [SerializeField] protected CircleCollider2D _collider2D;
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    [SerializeField] protected float bulletSpeed = 10f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
        this.LoadRigidbody2D();
    }

    protected override void Update()
    {
        base.Update();
        this.shootBullet();
    }

    protected void LoadCircleCollider2D()
    {
        if (this._collider2D != null) return;
        this._collider2D=transform.GetComponent<CircleCollider2D>();
        Debug.LogWarning(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    protected void LoadRigidbody2D()
    {
        if (this._rigidbody2D != null) return;
        this._rigidbody2D=transform.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

    protected void shootBullet()
    {
        transform.Translate(Vector3.up * this.bulletSpeed * Time.deltaTime);
        //this.DestroyObj();
    }
}
