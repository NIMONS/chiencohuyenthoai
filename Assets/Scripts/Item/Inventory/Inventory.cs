using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : CCHTMonoBehaviour
{
    [SerializeField] protected int maxSlots = 10;
    [SerializeField] protected List<GameObject> inventoryItems;

    public void AddItem(GameObject items)
    {
        if (this.inventoryItems.Count >= this.maxSlots)
        {
            Debug.Log("đã full slot");
            return;
        }
        this.inventoryItems.Add(items.transform.parent.gameObject);
        Debug.Log("Item đã được thêm vào túi!!!");
    }
}
