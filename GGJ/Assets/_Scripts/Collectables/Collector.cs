using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collector : MonoBehaviour
{
    [SerializeField] private KeyCode collectionKey;
    [SerializeField] private Collectable _collectable;

    public static event Action<Collectable> OnCollectableTaken;

    private void OnEnable()
    {
        OnCollectableTaken += TakeCollectable;
    }

    private void Update()
    {
        if (Input.GetKeyDown(collectionKey))
        {
            if (_collectable)
            {
                if (!_collectable.IsCollected && _collectable.IsPickable)
                {
                    OnCollectableTaken?.Invoke(_collectable);
                }
            }
        }
    }

    private void TakeCollectable(Collectable collectable)
    {
        Inventory.Instance.AddItem(collectable.entry);
    }

    private void OnTriggerEnter(Collider other)
    {
        _collectable = other.GetComponent<Collectable>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_collectable) _collectable = other.GetComponent<Collectable>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collectable>())
        {
            _collectable = null;
        }
    }
}