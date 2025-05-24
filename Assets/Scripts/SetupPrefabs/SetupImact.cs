using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupImact : CCHTMonoBehaviour
{
    [SerializeField] protected Transform model;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected void LoadModel()
    {
        if (this.model == null) return;
        this.model = transform.GetComponent<Transform>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
