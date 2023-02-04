using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class Collectable : MonoBehaviour
{
    [field: SerializeField] public ItemSO _itemToGive { get; private set; }
    public bool IsCollected = false;
    
    public InventoryEntry entry { get; private set; }

    private void Awake()
    {
        entry = new InventoryEntry(_itemToGive);
    }
}

