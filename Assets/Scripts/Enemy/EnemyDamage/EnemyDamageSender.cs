using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : CCHTMonoBehaviour
{   
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected Transform pointAttack;
    [SerializeField] protected BulletEneSpawner bulletSpawner;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 4f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadPointAttack();
        this.LoadBulletEneSpawner();
    }
    protected void LoadBulletEneSpawner()
    {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = GameObject.FindObjectOfType<BulletEneSpawner>();
        Debug.LogWarning(transform.name + ": LoadBulletEneSpawner", gameObject);
    }

    protected void LoadPointAttack()
    {
        if (this.pointAttack != null) return;
        this.pointAttack = transform.parent.Find("PointAttack");
        Debug.LogWarning(transform.name + ": LoadPointAttack", gameObject);
    }

    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        this.EnemyAttack();
    }

    protected void EnemyAttack()
    {
        Transform attackPos = enemyCtrl.EnemyMovement.TargetPos;
        if (attackPos != null) 
        {
            this.timer += Time.deltaTime;
            if (this.timer < this.timeDelay) return;
            Transform bulletTransform = bulletSpawner.Prefabs[0].transform;
            Transform bulletSpawned = Instantiate(bulletTransform, pointAttack.position, pointAttack.rotation);
            bulletSpawned.gameObject.SetActive(true);
            this.timer = 0;
            bulletSpawned.SetParent(bulletSpawner.Holder);
        }
    }
}
