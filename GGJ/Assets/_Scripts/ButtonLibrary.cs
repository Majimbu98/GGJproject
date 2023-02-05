using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ButtonLibrary : Singleton<ButtonLibrary>
{

#region Variables & Properties

[SerializeField] private Sprite muted;
[SerializeField] private Sprite smuted;
[SerializeField] private Button muteSmuteButton;
[SerializeField] private GameObject pauseScreen;
[SerializeField] private LevelSaving _levelSaving;
private bool mute = false;

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

public void MuteSmute()
{
    if (mute)
    {
        muteSmuteButton.GetComponent<Image>().sprite = smuted;
    }
    else
    {
        muteSmuteButton.GetComponent<Image>().sprite = muted;
    }

    //TODO
    mute = !mute;
}

public void Pause()
{
    pauseScreen.SetActive(false);
}

public void Resume()
{
    pauseScreen.SetActive(false);
}

public void OpenGame()
{
    SceneManager.LoadScene(_levelSaving.GetSceneName());
}

public void Quit()
{
    Application.Quit();
}

#endregion

}
