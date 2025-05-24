using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class InventoryItem
{
    public string itemName = "";
    public int itemCount = 0;
    public int upgradeLevel = 0;

    public InventoryItem clone()
    {
        InventoryItem item = new InventoryItem
        {
            itemName ="",
            itemCount = 0,
            upgradeLevel = 0
        };
        return item;
    }
}
