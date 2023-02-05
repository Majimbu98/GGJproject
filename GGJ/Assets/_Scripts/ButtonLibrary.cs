using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ButtonLibrary : Singleton<ButtonLibrary>
{

#region Variables & Properties

[SerializeField] private Sprite muted;
[SerializeField] private Sprite smuted;
[SerializeField] private Image muteSmuteButton;
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
        muteSmuteButton.sprite = smuted;
    }
    else
    {
        muteSmuteButton.sprite = muted;
    }

    //TODO
    mute = !mute;
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
