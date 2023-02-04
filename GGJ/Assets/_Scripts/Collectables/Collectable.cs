using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class Collectable : MonoBehaviour
{
    [field: SerializeField] public ItemSO _itemToGive { get; private set; }
    
    public bool IsCollected = false;
    [field: SerializeField] public bool IsPickable { get; private set; } = false;
    
    public InventoryEntry entry { get; private set; }

    private void Awake()
    {
        entry = new InventoryEntry(_itemToGive, this);
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(OnEnableCoroutine));
    }

    private void ActivateCollectable()
    {
        IsPickable = true;
    }

    IEnumerator OnEnableCoroutine()
    {
        yield return new WaitUntil((() => Inventory.Instance));
        
        Inventory.Instance.OnItemPickup.AddListener(_entry =>
        {
            if (entry == _entry) IsCollected = true;
            
            IsPickable = false;
        });
        
        Inventory.Instance.OnItemRemoved.AddListener(_entry =>
        {
            IsPickable = true;
        });
        
        QuestComponent.OnQuestStart += ActivateCollectable;
    }
}

