using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBullet : CCHTMonoBehaviour
{
    [SerializeField] protected BulletShipCtrl bulletShipCtrl;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform bulletSpawnPoint;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float shootDelay = 1f;
    //[SerializeField] protected bool isShoot = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletShipCtrl();
        this.LoadBulletPrefab();
        this.LoadBulletSpawnPoint();
    }

    protected override void Update()
    {
        base.Update();
        this.ShootBullet();
    }

    protected void LoadBulletSpawnPoint()
    {
        if (this.bulletSpawnPoint != null) return;
        this.bulletSpawnPoint = transform.GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadBulletSpawnPoint", gameObject);
    }

    protected void LoadBulletPrefab()
    {
        if (this.bulletPrefab != null) return;
        this.bulletPrefab = bulletShipCtrl.Bullet.GetComponent<GameObject>();
        Debug.LogWarning(transform.name + ": LoadBulletPrefab", gameObject);
    }

    protected void LoadBulletShipCtrl()
    {
        if (this.bulletShipCtrl != null) return;
        this.bulletShipCtrl = transform.parent.parent.parent.GetComponent<BulletShipCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletShipCtrl", gameObject);
    }

    protected void ShootBullet()
    {
        //if(!this.isShoot) return;
        this.shootTimer += Time.deltaTime;

        if(this.shootTimer>=this.shootDelay && Input.GetKey(KeyCode.Space))
        {
            this.Fire();
            //this.isShoot = true;
            this.shootTimer = 0;
        } 
    }

    protected void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
