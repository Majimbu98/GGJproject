using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeImage : Singleton<FadeImage>
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private LevelSaving savingData;
    
    protected override void Awake()
    {
        base.Awake();

        enabled = true;
    }
    
    public void FadeAndLoad(string sceneName)
    {
        LeanTween.value(gameObject, f =>
        {
            canvasGroup.alpha = f;
        }, 0, 1, .5f).setOnComplete((() =>
        {
            SceneManager.LoadSceneAsync(sceneName).completed += asyncOperation =>
            {
                savingData.SetLastScene(sceneName);
                LeanTween.value(gameObject, f =>
                {
                    canvasGroup.alpha= f;
                }, 1, 0 , .5f);
            };
        }));
    }
}

