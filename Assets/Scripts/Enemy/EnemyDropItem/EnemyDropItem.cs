using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItem : CCHTMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl=transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    public void IsEnemyDie()
    {
        this.TryDropItem();
    }

    protected void TryDropItem()
    {
        int randomValue = Random.Range(0, 100);
        Transform currentTransform = this.transform.parent;
        GameObject itemDrop = this.enemyCtrl.EnemySpawnerCtrl.SpawnerCtrl.ItemSpawner.Prefabs[0].gameObject;
        TakeItem takeItem = itemDrop.GetComponentInChildren<TakeItem>();
        if (takeItem == null)
        {
            Debug.Log("takeItem is null");
            return;
        }
        if(randomValue<= takeItem.DropChanceItem)
        {
            Transform instantiateItem= Instantiate(itemDrop.transform, currentTransform.position, currentTransform.rotation);
            instantiateItem.gameObject.SetActive(true);
            instantiateItem.SetParent(this.enemyCtrl.EnemySpawnerCtrl.SpawnerCtrl.ItemSpawner.Holder);
        }
    }
}
