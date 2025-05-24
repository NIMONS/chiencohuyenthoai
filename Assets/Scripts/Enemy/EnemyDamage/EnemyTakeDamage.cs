using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : CCHTMonoBehaviour
{
    [SerializeField] protected float dropChance = 65f;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected FXSpawner fxSpawner;
    [SerializeField] protected int health = 5;
    public int HeathEne => health;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadFXSpawner();
    }

    protected void LoadFXSpawner()
    {
        if (this.fxSpawner != null) return;
        this.fxSpawner = GameObject.FindObjectOfType<FXSpawner>();
        Debug.LogWarning(transform.name + ": LoadFXSpawner", gameObject);
    }

    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl=transform.parent.GetComponent<EnemyCtrl>();
        //Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    public void TakeDamage(int Damage)
    {
        this.health -= Damage;
        if (this.health <= 0) this.Die();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            this.SenDamage(collision);
        }
    }

    protected void Die()
    {

        Destroy(transform.parent.gameObject);
        PointSpawner pointSpawner = enemyCtrl.PointSpawner.gameObject.GetComponent<PointSpawner>();
        pointSpawner.DecreaseEnemiesSpawned();
        pointSpawner.RemoveAttackPosition(enemyCtrl.EnemyMovement.AttackPosition);
        Transform effectSpawner= fxSpawner.Prefabs[0].transform;
        Transform effectTransfrom= Instantiate(effectSpawner, transform.position, transform.rotation);
        effectTransfrom.gameObject.SetActive(true);
        effectTransfrom.SetParent(fxSpawner.Holder);

        this.enemyCtrl.EnemyDropItem.IsEnemyDie();
    }

    protected void SenDamage(Collision2D collision)
    {
        DamageSender damageSender = collision.transform.GetComponentInChildren<DamageSender>();
        if (damageSender == null) Debug.Log("damageSender is null"); 
        this.TakeDamage(damageSender.DamageSend);
        Destroy(damageSender.gameObject);
    }

}
