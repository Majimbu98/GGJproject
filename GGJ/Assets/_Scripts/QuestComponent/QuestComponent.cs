using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestComponent : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private ScriptableQuest quest;
[SerializeField] private Image ItemImage;
[SerializeField] private Text numberItem;


#endregion

#region MonoBehaviour

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        ItemImage.sprite = quest.GetSprite();
        numberItem.text = quest.GetNumber().ToString();
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



#endregion

}
