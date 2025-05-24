using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : CCHTMonoBehaviour
{
    [SerializeField] protected Bullet _bullet;
    public Bullet Bullet => _bullet;
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullet();
        this.LoadDamageSender();
    }

    protected void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.LogWarning(transform.name + ": LoadDamageSender", gameObject);
    }

    protected void LoadBullet()
    {
        if (this._bullet != null) return;
        this._bullet = transform.GetComponentInChildren<Bullet>();
        Debug.LogWarning(transform.name + ": LoadBullet", gameObject);
    }
}
