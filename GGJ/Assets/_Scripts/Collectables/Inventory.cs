using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : Singleton<Inventory>
{
    [field: SerializeField] public List<InventoryEntry> items { get; private set; }

    public UnityEvent<InventoryEntry> OnItemPickup;
    public UnityEvent<InventoryEntry> OnItemRemoved;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        Entity.OnCollectorCollision += RemoveItem;
    }

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

        if (item == null) return;
        
        item.Quantity--;
        item.owner.IsCollected = false;

        if (item.Quantity <= 0)
        {
            items.Remove(item);
        }

        OnItemRemoved?.Invoke(newEntry);
    }
}