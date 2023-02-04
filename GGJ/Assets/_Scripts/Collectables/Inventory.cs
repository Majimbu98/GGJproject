using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : Singleton<Inventory>
{
    [field: SerializeField] public List<InventoryEntry> items { get; private set; }

    public UnityEvent<InventoryEntry> OnItemPickup;

    public void AddItem(InventoryEntry newEntry)
    {
        if (items.Contains(newEntry))
        {
            items.Find(entry => entry == newEntry).Quantity++;
        }
        else
        {
            newEntry.Quantity++;
            items.Add(newEntry);
        }
        
        OnItemPickup?.Invoke(newEntry);
    }
}