using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : Singleton<Inventory>
{
    [field: SerializeField] public List<InventoryEntry> items { get; private set; }

    public UnityEvent<InventoryEntry> OnItemPickup;

    public void AddItem(InventoryEntry newEntry)
    {
        var item = items.Find(entry => entry.Item == newEntry.Item);
        
        if (item != null)
        {
            item.Quantity++;
        }
        else
        {
            items.Add(newEntry);
        }
        
        OnItemPickup?.Invoke(newEntry);
    }
}