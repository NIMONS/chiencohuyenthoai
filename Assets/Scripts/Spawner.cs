using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : CCHTMonoBehaviour
{
    [SerializeField] protected Transform holder;
    public Transform Holder => holder;
    [SerializeField] protected List<Transform> prefabs;
    public List<Transform> Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }


    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    protected void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform i in prefabObj)
        {
            this.prefabs.Add(i);
            this.hidePrefab();
        }
    }

    protected void hidePrefab()
    {
        foreach (Transform t in this.prefabs)
        {
            t.gameObject.SetActive(false);
        }
    }
}
