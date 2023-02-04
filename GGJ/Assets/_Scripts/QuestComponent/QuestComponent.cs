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
[SerializeField] private KeyCode interactKey;
[SerializeField] private EnumStateQuest stateQuest;
private bool completed = false;
private bool canInteract = false;

public static event Action OnQuestStart;
public static event Action OnItemGive;

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
        if (completed) return;
        
        if (Input.GetKeyDown(interactKey) && canInteract)
        {
            if (stateQuest == EnumStateQuest.NotStarted)
            {
                OnQuestStart?.Invoke();
                stateQuest = EnumStateQuest.Started;
            }
            else
            {
                OnItemGive?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
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
        completed = true;
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
