using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level saving file", menuName = " Level Saving File")]
public class LevelSaving : ScriptableObject
{

#region Variables & Properties

[SerializeField] private string lastScene;
[SerializeField] private bool ResetLevels = false;
private string FirstScene = "StartingCutScene";

#endregion

#region MonoBehaviour

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if (ResetLevels)
        {
            lastScene = FirstScene;
        }
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

public void SetLastScene(string newScene)
{
    lastScene = newScene;
}

public string GetSceneName()
{
    return lastScene;
}

#endregion

}
