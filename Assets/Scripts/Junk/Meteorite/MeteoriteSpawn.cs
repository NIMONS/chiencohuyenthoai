using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawn : MoveObjcet
{

    [SerializeField] protected JunkSpawner itemSpawner;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timerDelay = 4f;
    [SerializeField] protected List<Transform> listPointSpawnMeteorite;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListPointSpawnMeteorite();
        this.LoadItemSpawner();
    }

    protected void LoadItemSpawner()
    {
        if (this.itemSpawner != null) return;
        this.itemSpawner = transform.parent.GetComponent<JunkSpawner>();
        Debug.LogWarning(transform.name + ": LoadItemSpawner", gameObject);
    }

    protected void LoadListPointSpawnMeteorite()
    {
        if (this.listPointSpawnMeteorite.Count > 0) return;
        Transform objContainPoint = this.transform;
        foreach(Transform i in objContainPoint)
        {
            this.listPointSpawnMeteorite.Add(i);
        }
        Debug.LogWarning(transform.name + ": LoadListPointSpawnMeteorite", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        this.SpawnMeteorite();
    }

    protected void SpawnMeteorite()
    {
        this.timer += Time.deltaTime;
        Transform meteoritePrefab = this.randPrefabs();
        if (this.timer >= this.timerDelay)
        {
            Transform objRandom = this.randObj();
            Transform spawnObjatPoint = Instantiate(meteoritePrefab.transform, objRandom.position, objRandom.rotation);
            spawnObjatPoint.gameObject.SetActive(true);
            spawnObjatPoint.SetParent(this.itemSpawner.Holder);
            this.timer = 0;
        }

    }

    protected Transform randPrefabs()
    {
        int randomPrefabIndex = Random.Range(0, this.itemSpawner.Prefabs.Count);
        return this.itemSpawner.Prefabs[randomPrefabIndex];
    }

    protected Transform randObj()
    {
        int randomIndex = Random.Range(0, this.listPointSpawnMeteorite.Count);
        return this.listPointSpawnMeteorite[randomIndex];
    }
}
