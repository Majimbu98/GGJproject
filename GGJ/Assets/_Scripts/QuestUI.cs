using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private Image ItemImage;
[SerializeField] private TMP_Text numberItem;
private int index=0;

#endregion

#region MonoBehaviour

    // Awake is called when the script instance is being loaded
    void Awake()
    {
	
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#endregion

#region Methods

public void SetData(ScriptableQuest quest)
{
    ItemImage.sprite = quest.GetSprite();
    numberItem.text = $"{index}/{quest.GetNumber()}";
}

public void SetData(int _index, ScriptableQuest quest)
{
    index += _index;
    numberItem.text = $"{index}/{quest.GetNumber()}";
}

#endregion

}
