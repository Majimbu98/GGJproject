using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private GameObject firstImage;
[SerializeField] private GameObject secondImage;
[SerializeField] private GameObject thirdImage;
[SerializeField] private GameObject fourthImage;

[SerializeField] private float timer1;
[SerializeField] private float timer2;
[SerializeField] private float timer3;
[SerializeField] private float timer4;
[SerializeField] private LevelSaving savingData;

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
    yield return StartCoroutine(TimerCutScene(firstImage, secondImage, timer1));
    yield return StartCoroutine(TimerCutScene(secondImage, thirdImage, timer2));
    yield return StartCoroutine(TimerCutScene(thirdImage, fourthImage, timer3));
    yield return new WaitForSeconds(timer4);
    
    savingData.SetLastScene("Level1");
    SceneManager.LoadScene("Level1");

}

private IEnumerator TimerCutScene(GameObject newFirstImage, GameObject newSecondImage, float time)
{
    //TODO BETTER... maybe becoming black with transition and sound?
    yield return new WaitForSeconds(time);
    newFirstImage.SetActive(false);
    newSecondImage.SetActive(true);
}

#endregion

}
