using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Collectable : MonoBehaviour
{
    [field: SerializeField] public ItemSO _itemToGive { get; private set; }
    public bool IsCollected = false;
}

