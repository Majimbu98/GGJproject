using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseClass : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private KeyCode key;
private bool pause=false;
[SerializeField] private GameObject canvasParent;
public static event Action OnPause; 
public static event Action OnUnPause;


#endregion

#region MonoBehaviour

private void OnEnable()
{
    OnPause+= OnOnPause;
    OnUnPause+= OnOnUnPause;
}

private void OnOnUnPause()
{
    canvasParent.SetActive(false);
}

private void OnOnPause()
{
    canvasParent.SetActive(true);
}

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
            pause = !pause;
            
            if (pause)
            {
                OnPause?.Invoke();
            }
            else
            {
                OnUnPause?.Invoke();
            }
        }
    }

#endregion

#region Methods

public void UnPause()
{
    OnUnPause?.Invoke();
}

#endregion

}
