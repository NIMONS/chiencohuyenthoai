using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCtrl : CCHTMonoBehaviour
{
    [SerializeField] protected Movement movementSpaceship;
    public Movement MovementSpaceship => movementSpaceship;

    [SerializeField] protected BulletShipCtrl bulletShipCtrl;
    public BulletShipCtrl BulletShipCtrl => bulletShipCtrl;
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMovenmentSpaceship();
        this.LoadBulletShipCtrl();
        this.LoadInventory();
    }

    protected void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        Debug.LogWarning(transform.name + ": LoadInventory", gameObject);
    }

    protected void LoadBulletShipCtrl()
    {
        if (this.bulletShipCtrl != null) return;
        this.bulletShipCtrl = transform.GetComponentInChildren<BulletShipCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletShipCtrl", gameObject);
    }

    protected void LoadMovenmentSpaceship()
    {
        if (this.movementSpaceship != null) return;
        this.movementSpaceship = transform.GetComponentInChildren<Movement>();
        Debug.LogWarning(transform.name + ": LoadMovenmentSpaceship", gameObject);
    }
}
