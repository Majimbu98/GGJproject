using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwerActivator : MonoBehaviour
{

    [SerializeField] private List<SpawnLogs> Spawners;

    void OnItemGive(InventoryEntry Item)
    {
        if (Item == null) return;
        if (Spawners.Count <= 0) return;
        Spawners[0].gameObject.SetActive(true);
        Spawners.RemoveAt(0);
    }
    
    // Start is called before the first frame update
    void OnEnable ()
    {
        QuestComponent.OnItemGive += OnItemGive;
    }

}
