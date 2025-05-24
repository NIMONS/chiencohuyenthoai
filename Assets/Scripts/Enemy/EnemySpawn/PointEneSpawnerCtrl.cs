using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEneSpawnerCtrl : CCHTMonoBehaviour
{
    [SerializeField] protected PointAttack pointAttack;
    public PointAttack PointAttack => pointAttack;
    [SerializeField] protected PointSpawner pointSpawner;
    public PointSpawner PointSpawner => pointSpawner;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPointAttack();
        this.LoadPointSpawner();
        this.LoadEnemyCtrl();
    }

    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.Find("Prefabs").GetComponentInChildren<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected void LoadPointSpawner()
    {
        if (this.pointSpawner != null) return;
        this.pointSpawner = transform.GetComponentInChildren<PointSpawner>();
        Debug.LogWarning(transform.name + ": LoadPointSpawner", gameObject);
    }

    protected void LoadPointAttack()
    {
        if (this.pointAttack != null) return;
        this.pointAttack = transform.GetComponentInChildren<PointAttack>();
        Debug.LogWarning(transform.name + ": LoadPointAttack", gameObject);
    }

}
