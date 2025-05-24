using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : CCHTMonoBehaviour
{
    [SerializeField] protected Enemy enemy;
    public Enemy Enemy => enemy;

    [SerializeField] protected PointSpawner pointSpawner;
    public PointSpawner PointSpawner => pointSpawner;
    [SerializeField] protected PointAttack pointAttack;
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement EnemyMovement => enemyMovement;
    [SerializeField] protected EnemyTakeDamage enemyTakeDamage;
    public EnemyTakeDamage EnemyTakeDamage => enemyTakeDamage;
    [SerializeField] protected EnemyDropItem enemyDropItem;
    public EnemyDropItem EnemyDropItem => enemyDropItem;
    [SerializeField] protected EnemySpawnerCtrl enemySpawnerCtrl;
    public EnemySpawnerCtrl EnemySpawnerCtrl => enemySpawnerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemy();
        this.LoadPointSpawner();
        this.LoadPointAttack();
        this.LoadEnemyMovement();
        this.LoadEnemyTakeDamage();
        this.LoadEnemyDropItem();
        this.LoadEnemySpawnerCtrl();
    }

    protected void LoadEnemySpawnerCtrl()
    {
        if (this.enemySpawnerCtrl != null) return;
        this.enemySpawnerCtrl = transform.parent.parent.GetComponent<EnemySpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawnerCtrl", gameObject);
    }

    protected void LoadEnemyDropItem()
    {
        if (this.enemyDropItem != null) return;
        this.enemyDropItem = transform.GetComponentInChildren<EnemyDropItem>();
        Debug.LogWarning(transform.name + ": LoadEnemyDropItem", gameObject);
    }

    protected void LoadEnemyTakeDamage()
    {
        if (this.enemyTakeDamage != null) return;
        this.enemyTakeDamage=transform.GetComponentInChildren<EnemyTakeDamage>();
        Debug.LogWarning(transform.name + ": LoadEnemyTakeDamage", gameObject);
    }

    protected void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement = transform.GetComponentInChildren<EnemyMovement>();
        Debug.LogWarning(transform.name + ": LoadEnemyMovement", gameObject);
    }

    protected void LoadPointAttack()
    {
        if (this.pointAttack != null) return;
        this.pointAttack = transform.parent.parent.Find("PointEneSpawner").GetComponentInChildren<PointAttack>();
        Debug.LogWarning(transform.name + ": LoadPointAttack", gameObject);
    }

    protected void LoadPointSpawner()
    {
        if (this.pointSpawner != null) return;
        this.pointSpawner = transform.parent.parent.Find("PointEneSpawner").GetComponentInChildren<PointSpawner>();
        Debug.LogWarning(transform.name + ": LoadPointSpawner", gameObject);
    }

    protected void LoadEnemy()
    {
        if (this.enemy != null) return;
        this.enemy=transform.GetComponentInChildren<Enemy>();
        Debug.LogWarning(transform.name + ": LoadEnemy", gameObject);
    }
}
