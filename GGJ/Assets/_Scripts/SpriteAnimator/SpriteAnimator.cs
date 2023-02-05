using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private List<Sprite> spriteList;
[SerializeField] private float time;
[SerializeField] private Sprite mySprite;
[SerializeField] private bool timeFrame;

#endregion

#region MonoBehaviour

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        StartCoroutine(StartAnimation());
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

private IEnumerator StartAnimation()
{
    int index = 0;
    
    while (true)
    {
        mySprite = spriteList[index];
        index++;
        
        if (index == spriteList.Count)
        {
            index = 0;
        }

        if (timeFrame)
        {
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(time);
        }
        
    }
}

#endregion

}
