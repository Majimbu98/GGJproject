using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseClass : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private KeyCode key;
public static event Action OnPause;
public static event Action OnUnPause;

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
        if (Input.GetKeyDown(key))
        {
            
        }
    }

#endregion

#region Methods

private void ActivePauseScreen()
{
    
}

private void DeactivePauseScreen()
{
    
}

#endregion

}
