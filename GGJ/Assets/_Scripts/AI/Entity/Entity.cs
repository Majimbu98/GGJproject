using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Entity : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject target;
    [SerializeField] private ItemSO item;

    private Vector3 startPosition;
    private Quaternion startRotation;
    
    public static event Action<InventoryEntry> OnCollectorCollision; 

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }

    private void Start()
    {
        Inventory.Instance.OnItemPickup.AddListener(ActivateEntity);

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!agent.enabled) return;
        agent.destination = target.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Collector>();

        if (player)
        {
            OnCollision();
        }
    }

    protected virtual void OnCollision()
    {
        OnCollectorCollision?.Invoke(new InventoryEntry(item));

        LeanTween.moveY(gameObject, 20f, 4f).setOnComplete(ResetEntity);
    }

    private void ActivateEntity(InventoryEntry arg0)
    {
        gameObject.SetActive(true);
        agent.enabled = true;
    }
    
    private void ResetEntity()
    {
        transform.position = startPosition;
        gameObject.SetActive(false);
        agent.enabled = false;
    }

    IEnumerator OnEnableCoroutine()
    {
        yield return new WaitUntil((() => Inventory.Instance));
        
    }
}

