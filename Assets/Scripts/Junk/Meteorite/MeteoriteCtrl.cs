using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCtrl : CCHTMonoBehaviour
{
    [SerializeField] protected Meteorite model;
    public Meteorite Model => model;
    [SerializeField] protected MeteoriteDespawn meteoriteDespawn;
    public MeteoriteDespawn MeteoriteDespawn => meteoriteDespawn;
    [SerializeField] protected MeteoriteMovement meteoriteMovement;
    public MeteoriteMovement MeteoriteMovement => meteoriteMovement;
    [SerializeField] protected MeteoriteTakeDamage meteoriteTakeDamage;
    public MeteoriteTakeDamage MeteoriteTakeDamage => meteoriteTakeDamage;
    [SerializeField] protected MeteoriteDropItem meteoriteDropItem;
    public MeteoriteDropItem MeteoriteDropItem => meteoriteDropItem;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeteoriteModel();
        this.LoadMeteoriteDespawn();
        this.LoadMeteoriteMovement();
        this.LoadMeteoriteTakeDamage();
        this.LoadMeteoriteDropItem();
    }

    protected void LoadMeteoriteDropItem()
    {
        if (this.meteoriteDropItem != null) return;
        this.meteoriteDropItem = transform.GetComponentInChildren<MeteoriteDropItem>();
        Debug.LogWarning(transform.name + ": LoadMeteoriteDropItem", gameObject);
    }

    protected void LoadMeteoriteTakeDamage()
    {
        if (this.meteoriteTakeDamage != null) return;
        this.meteoriteTakeDamage = transform.GetComponentInChildren<MeteoriteTakeDamage>();
        Debug.LogWarning(transform.name + ": LoadMeteoriteTakeDamage", gameObject);
    }

    protected void LoadMeteoriteMovement()
    {
        if (this.meteoriteMovement != null) return;
        this.meteoriteMovement = transform.GetComponentInChildren<MeteoriteMovement>();
        Debug.LogWarning(transform.name + ": LoadMeteoriteMovement", gameObject);
    }

    protected void LoadMeteoriteDespawn()
    {
        if (this.meteoriteDespawn != null) return;
        this.meteoriteDespawn = transform.GetComponentInChildren<MeteoriteDespawn>();
        Debug.LogWarning(transform.name + ": LoadMeteoriteDespawn", gameObject);
    }

    protected void LoadMeteoriteModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<Meteorite>();
        Debug.LogWarning(transform.name + ": LoadMeteoriteModel", gameObject);
    }
}
