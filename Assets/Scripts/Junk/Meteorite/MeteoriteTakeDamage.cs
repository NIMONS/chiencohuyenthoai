using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteTakeDamage : CCHTMonoBehaviour
{
    [SerializeField] protected MeteoriteCtrl meteoriteCtrl;
    [SerializeField] protected FXSpawner fxSpawner;
    [SerializeField] protected int health = 6;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeteoriteCtrl();
        this.LoadFXSpawner();
    }

    protected void LoadFXSpawner()
    {
        if (this.fxSpawner != null) return;
        this.fxSpawner = GameObject.FindObjectOfType<FXSpawner>();
        Debug.LogWarning(transform.name + ": LoadFXSpawner", gameObject);
    }

    protected void LoadMeteoriteCtrl()
    {
        if (this.meteoriteCtrl != null) return;
        this.meteoriteCtrl=transform.parent.GetComponent<MeteoriteCtrl>();
        Debug.LogWarning(transform.name + ": LoadMeteoriteCtrl", gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int damageSendMeteorite = this.meteoriteCtrl.MeteoriteMovement.SpaceshipCtrl.BulletShipCtrl.BulletCtrl.DamageSender.DamageSendMeteorite;
            this.MeteTakeDamage(damageSendMeteorite);
        }
    }

    protected override void Update()
    {
        base.Update();
    }

    public void MeteTakeDamage(int damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            this.DestroyObj();
            this.MeteoriteDropItem();
        }

    }

    protected void DestroyObj()
    {
        Transform smokeTransform = this.fxSpawner.Prefabs[0].transform;
        Transform currentTransform = this.transform.parent;
        Transform smokeSpawn = Instantiate(smokeTransform, currentTransform.position, currentTransform.rotation);
        smokeSpawn.gameObject.SetActive(true);
        smokeSpawn.SetParent(this.fxSpawner.Holder);
        Destroy(transform.parent.gameObject);
    }

    protected void MeteoriteDropItem()
    {
        Debug.Log("Nhận vật phẩm!");
        this.meteoriteCtrl.MeteoriteDropItem.SpawnObjDrop();
    }
}
