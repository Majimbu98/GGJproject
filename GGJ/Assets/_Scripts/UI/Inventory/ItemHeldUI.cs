using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemHeldUI : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(OnEnableCoroutine));
    }

    private void AddImage(InventoryEntry entry)
    {
        image.color = Color.white;
        image.sprite = entry.Item.Sprite;
    }
    
    private void RemoveImage(InventoryEntry entry)
    {
        image.color = Color.clear;
        image.sprite = null;
    }

    IEnumerator OnEnableCoroutine()
    {
        yield return new WaitUntil((() => Inventory.Instance));
        
        Inventory.Instance.OnItemPickup.AddListener(AddImage);
        Inventory.Instance.OnItemRemoved.AddListener(RemoveImage);
        QuestComponent.OnItemGive += RemoveImage;
    }
}

