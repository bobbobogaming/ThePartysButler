using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryObject")]

public class InventoryObject : ScriptableObject
{
    public InventoryItemObject[] items;

    public void AddItem(string item)
    {
        var itemObj = items.FirstOrDefault(i => i.item.Equals(item));
        if (itemObj == null)
        {
            items = items.Append(new() { item = item, amount = 1 }).ToArray();
            return;
        }
        itemObj.amount++;
    }
}
