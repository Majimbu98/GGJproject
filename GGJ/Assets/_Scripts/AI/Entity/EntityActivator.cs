using System;
using System.Collections.Generic;
using UnityEngine;

public class EntityActivator : MonoBehaviour
{
    [SerializeField] private List<Entity> entitiesToActivate;
    private Collectable owner;

    private void Awake()
    {
        owner = GetComponent<Collectable>();
    }

    private void Start()
    {
        Inventory.Instance.OnItemPickup.AddListener(ActivateEntities);
    }

    private void ActivateEntities(InventoryEntry entry)
    {
        if(owner.entry != entry) return;

        foreach (var entity in entitiesToActivate)
        {
            entity.gameObject.SetActive(true);
            entity.agent.enabled = true;
        }
    }
}

