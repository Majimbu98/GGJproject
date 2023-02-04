using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestComponent : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private ScriptableQuest quest;
[SerializeField] private QuestUI questUI;
[SerializeField] private Transform finalPosition;
[SerializeField] private float speed;

#endregion

#region MonoBehaviour

// Awake is called when the script instance is being loaded
    void Awake()
    {
        questUI.SetData(quest);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(OnEnableCoroutine));
    }

    #endregion

#region Methods

private void CheckCompletion(InventoryEntry entry)
{
    if (entry.Quantity == quest.GetNumber())
    {
        questUI.gameObject.SetActive(false);
        LeanTween.move(gameObject, finalPosition.position, speed);
    }
}

IEnumerator OnEnableCoroutine()
{
    yield return new WaitUntil((() => Inventory.Instance));
    Inventory.Instance.OnItemPickup.AddListener(CheckCompletion);
}

#endregion

}
