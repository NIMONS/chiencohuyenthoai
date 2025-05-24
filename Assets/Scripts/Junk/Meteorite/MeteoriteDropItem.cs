using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDropItem : CCHTMonoBehaviour
{
    [SerializeField] protected GameObject objDrop;
    public GameObject ObjDrop => objDrop;

    [SerializeField] protected SpawnerCtrl spawnerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
    }

    protected void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl=transform.parent.parent.parent.parent.GetComponent<SpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpawnerCtrl", gameObject);
    }

    public void SpawnObjDrop()
    {
        if (this.objDrop == null) return;
        Transform currentObj = this.transform.parent;
        Transform newObjDrop = Instantiate(this.objDrop.transform, currentObj.position, currentObj.rotation);
        newObjDrop.gameObject.SetActive(true);
        newObjDrop.SetParent(this.spawnerCtrl.ItemSpawner.Holder);
    }
}
