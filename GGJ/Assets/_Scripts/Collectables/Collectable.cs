using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private ItemSO _itemToGive;

    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
    }
}

