using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletShipCtrl : CCHTMonoBehaviour
{
    [SerializeField] protected SpaceshipCtrl spaceshipCtrl;
    [SerializeField] protected Bullet bullet;
    [SerializeField] protected Holder holder;
    public Bullet Bullet => bullet;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform bulletSpawnPoint;
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float shootDelay = 0.5f;
    [SerializeField] protected float shootLimit = 0f;
    protected bool isBuffing = false;
    protected float timeLimit;
    protected float originalShootDelay;

	protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullet();
        this.LoadSpaceshipCtrl();
        this.LoadBulletPrefab();
        this.LoadBulletSpawnPoint();
        this.LoadHolder();
        this.LoadBulletCtrl();
    }

    protected void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.Find("Prefabs").Find("Bullet_1").GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletCtrl", gameObject);
    }

    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = GameObject.FindFirstObjectByType<Holder>();
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }

    protected void LoadBulletSpawnPoint()
    {
        if (this.bulletSpawnPoint != null) return;
        this.bulletSpawnPoint = spaceshipCtrl.transform.Find("PointBullet").GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadBulletSpawnPoint", gameObject);
    }

    protected void LoadBulletPrefab()
    {
        if (this.bulletPrefab != null) return;

        Transform bulletTransform = transform.Find("Prefabs/Bullet_1");

        this.bulletPrefab = bulletTransform.gameObject;
        Debug.LogWarning(transform.name + ": LoadBulletPrefab", gameObject);
    }

    protected void LoadSpaceshipCtrl()
    {
        if (this.spaceshipCtrl != null) return;
        this.spaceshipCtrl = transform.parent.GetComponent<SpaceshipCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpaceshipCtrl", gameObject);
    }

    protected void LoadBullet()
    {
        if (this.bullet != null) return;
        Transform pathBullet = transform.Find("Prefabs/Bullet_1/Modelbullet_1");
        this.bullet = pathBullet.GetComponent<Bullet>();
        Debug.LogWarning(transform.name + ": LoadBullet", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        this.ShootBullet();

		if (this.isBuffing)
		{
			this.shootLimit += Time.deltaTime;

			if (this.shootLimit >= 4f)
			{
				this.shootDelay = this.originalShootDelay; // Khôi phục lại ban đầu
				this.isBuffing = false;
				this.shootLimit = 0;
			}
		}
	}

    protected void OnBecameInvisible()
    {
        Destroy(this.bullet);
    }

    protected void ShootBullet()
    {
        //if(!this.isShoot) return;
        this.shootTimer += Time.deltaTime;

        if (this.shootTimer >= this.shootDelay && Input.GetKey(KeyCode.Space))
        {
            this.Fire();
            //this.isShoot = true;
            this.shootTimer = 0;
        }
    }

    protected void Fire()
    {
        GameObject clonebulletPrefab=Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        clonebulletPrefab.transform.gameObject.SetActive(true);
        clonebulletPrefab.transform.SetParent(this.holder.transform);
    }

    public void SetSpeedShoot()
    {
        if (this.shootDelay <= 0.3) return;
		this.shootDelay -= 0.03f; 
    }

    protected void StartSpeedBuff(float timeLimit)
    {
        if(!this.isBuffing)
        {
            this.originalShootDelay = this.shootDelay;
            this.shootDelay /= timeLimit;
            this.isBuffing = true;
            this.shootLimit = 0;
        }
    }

    public void setTimeandConfirmShoot(float timeLimit, bool confirm)
    {
		this.StartSpeedBuff(timeLimit);
		this.isBuffing = confirm;
        //this.timeLimit = timeLimit;
    }
}
