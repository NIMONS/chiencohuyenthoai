using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SpaceModel : CCHTMonoBehaviour
{
    [SerializeField] protected SpaceshipCtrl spaceshipCtrl;
    [SerializeField] protected CircleCollider2D _circleCollider2D;
    [SerializeField] protected Rigidbody2D _rigidbody2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
        this.LoadRigidbody2D();
        this.LoadSpaceshipCtrl();
    }

    protected void LoadSpaceshipCtrl()
    {
        if (this.spaceshipCtrl != null) return;
        this.spaceshipCtrl = transform.parent.GetComponent<SpaceshipCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpaceshipCtrl", gameObject);
    }

    protected void LoadRigidbody2D()
    {
        if (this._rigidbody2D != null) return;
        this._rigidbody2D = transform.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

    protected void LoadCircleCollider2D()
    {
        if (this._circleCollider2D != null) return;
        this._circleCollider2D = transform.GetComponent<CircleCollider2D>();
        Debug.LogWarning(transform.name + ": loadCircleCollider2D", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            this.TakeIItem(collision);
        }
    }

    protected void TakeIItem(Collider2D collision)
    {
        this.spaceshipCtrl.Inventory.AddItem(collision.gameObject);
    }
}
