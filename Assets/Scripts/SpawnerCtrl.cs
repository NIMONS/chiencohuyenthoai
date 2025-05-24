using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : CCHTMonoBehaviour
{
    [SerializeField] protected EnemySpawnerCtrl enemySpawnerCtrl;
    public EnemySpawnerCtrl EnemySpawnerCtrl => enemySpawnerCtrl;
    [SerializeField] protected FXSpawner fXSpawner;
    public FXSpawner FXSpawner => fXSpawner;
    [SerializeField] protected BulletEneSpawner bulletEneSpawner;
    public BulletEneSpawner BulletEneSpawner => bulletEneSpawner;
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;
    [SerializeField] protected ItemSpawner itemSpawner;
    public ItemSpawner ItemSpawner => itemSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawnerCtrl();
        this.LoadFXSpawner();
        this.LoadBulletEneSpawner();
        this.LoadJunkSpawner();
        this.LoadItemSpawner();
    }

    protected void LoadItemSpawner()
    {
        if (this.itemSpawner != null) return;
        this.itemSpawner = transform.GetComponentInChildren<ItemSpawner>();
        Debug.LogWarning(transform.name + ": LoadItemSpawner", gameObject);
    }

    protected void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = transform.GetComponentInChildren<JunkSpawner>();
        Debug.LogWarning(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected void LoadBulletEneSpawner()
    {
        if (this.bulletEneSpawner != null) return;
        this.bulletEneSpawner = transform.GetComponentInChildren<BulletEneSpawner>();
        Debug.LogWarning(transform.name + ": LoadBulletEneSpawner", gameObject);
    }

    protected void LoadFXSpawner()
    {
        if (this.fXSpawner != null) return;
        this.fXSpawner = transform.GetComponentInChildren<FXSpawner>();
        Debug.LogWarning(transform.name + ": LoadFXSpawner", gameObject);
    }

    protected void LoadEnemySpawnerCtrl()
    {
        if (this.enemySpawnerCtrl != null) return;
        this.enemySpawnerCtrl=transform.GetComponentInChildren<EnemySpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawnerCtrl", gameObject);
    }
}
