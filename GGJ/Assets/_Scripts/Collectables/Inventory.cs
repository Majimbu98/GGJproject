using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : Singleton<Inventory>
{
    [field: SerializeField] public List<InvetoryEntry> items { get; private set; }

    public UnityEvent<InvetoryEntry> OnItemPickup;

    public void AddItem(InvetoryEntry newEntry)
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