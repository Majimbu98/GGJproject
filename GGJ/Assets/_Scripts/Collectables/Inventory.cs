using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : Singleton<Inventory>
{
    [field: SerializeField] public List<InventoryEntry> items { get; private set; }

    public UnityEvent<InventoryEntry> OnItemPickup;
    public UnityEvent<InventoryEntry> OnItemRemoved;

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
    
    public void RemoveItem(InventoryEntry newEntry)
    {
        var item = items.Find(entry => entry.Item == newEntry.Item);

        item.Quantity--;
        
        if (item.Quantity <= 0)
        {
            items.Remove(item);
        }
        
        OnItemRemoved?.Invoke(newEntry);
    }
}