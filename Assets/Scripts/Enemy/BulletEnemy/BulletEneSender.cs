using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEneSender : DestroyByDistance
{
    [SerializeField] protected BulletEneSpawner bulletEneSpawner;
    [SerializeField] protected FXSpawner _fxSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFXSpawner();
        this.LoadBulletEneSpawner();
    }

    protected void LoadBulletEneSpawner()
    {
        if (this.bulletEneSpawner != null) return;
        this.bulletEneSpawner = transform.parent.parent.parent.GetComponent<BulletEneSpawner>();
        Debug.LogWarning(transform.name + ": LoadBulletEneSpawner", gameObject);
    }

    protected void LoadFXSpawner()
    {
        if (this._fxSpawner != null) return;
        this._fxSpawner=GameObject.FindObjectOfType<FXSpawner>();
        Debug.LogWarning(transform.name + ": LoadFXSpawner", gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.CauseDamage();
        }
    }

    protected void CauseDamage()
    {
        //Debug.Log("Cause damage player");
        Destroy(transform.parent.gameObject);
        Transform effectImpartEne= _fxSpawner.Prefabs[1].transform;
        Transform effctImpartEneSpawn = Instantiate(effectImpartEne, transform.position, transform.rotation);
        effctImpartEneSpawn.gameObject.SetActive(true);
        effctImpartEneSpawn.SetParent(bulletEneSpawner.Holder);
    }

}
