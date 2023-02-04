using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private Image image;
[SerializeField] private List<Sprite> spriteList;
[SerializeField] private float timer;

#endregion

#region MonoBehaviour

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        StartCoroutine(TimeCutSceneGeneral());
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

private IEnumerator TimeCutSceneGeneral()
{
    foreach (var sprite in spriteList)
    {
        bool isDone = false;
        image.sprite = sprite;
        LeanTween.value(gameObject, Color =>
        {
            image.color = Color;
        }, Color.black, Color.white, 0.5f).setOnComplete((() =>
        {
            LeanTween.delayedCall(timer, () =>
            {
                LeanTween.value(gameObject, Color =>
                {
                    image.color = Color;
                }, Color.white, Color.black, 0.25f).setOnComplete((() =>
                {
                    isDone = true;
                }));
            });
        }));

        yield return new WaitUntil((() => isDone));
    }
    
    FadeImage.Instance.FadeAndLoad("Level1");

}

#endregion

}
