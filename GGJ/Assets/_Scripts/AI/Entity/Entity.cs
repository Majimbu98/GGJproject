using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private List<Entity> entities;

    public static event Action<InventoryEntry> OnCollectorCollision; 

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;

        entities = FindObjectsOfType<Entity>().ToList();
    }

    private void Start()
    {
        Inventory.Instance.OnItemPickup.AddListener(ActivateEntity);
        QuestComponent.OnItemGive += ResetEntities;

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

        ResetEntities(new InventoryEntry(item));
    }

    private void ResetEntities(InventoryEntry entry)
    {
        foreach (var entity in entities)
        {
            LeanTween.moveY(entity.gameObject, 20f, 4f).setOnComplete((() =>
            {
                entity.transform.position = entity.startPosition;
                entity.gameObject.SetActive(false);
                entity.agent.enabled = false;
            }));
        }
    }

    private void ActivateEntity(InventoryEntry arg0)
    {
        gameObject.SetActive(true);
        agent.enabled = true;
    }
}

