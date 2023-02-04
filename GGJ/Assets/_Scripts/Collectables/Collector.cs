using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Collector : MonoBehaviour
{
    [SerializeField] private KeyCode collectionKey;
    [SerializeField] private Collectable _collectable;

    private event Action<Collectable> OnCollectableTaken;

    private void OnEnable()
    {
        OnCollectableTaken += TakeCollectable;
    }

    private void TakeCollectable(Collectable collectable)
    {
        Inventory.Instance.AddItem(collectable.entry);
        collectable.IsCollected = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        _collectable = other.GetComponent<Collectable>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_collectable) _collectable = other.GetComponent<Collectable>();
        
        if (Input.GetKeyDown(collectionKey))
        {
            if (_collectable && !_collectable.IsCollected)
            {
                OnCollectableTaken?.Invoke(_collectable);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collectable>())
        {
            _collectable = null;
        }
    }
}