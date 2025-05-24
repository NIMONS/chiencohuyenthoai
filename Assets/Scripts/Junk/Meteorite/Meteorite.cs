using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Meteorite : CCHTMonoBehaviour
{
    [SerializeField] protected CircleCollider2D _circleCollider;
    [SerializeField] protected Rigidbody2D _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
        this.LoadRigidbody2D();
    }

    protected void LoadRigidbody2D()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

    protected void LoadCircleCollider2D()
    {
        if (this._circleCollider != null) return;
        this._circleCollider=transform.GetComponent<CircleCollider2D>();
        Debug.LogWarning(transform.name + ": LoadCircleCollider2D", gameObject);
    }

}
