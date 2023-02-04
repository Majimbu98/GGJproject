using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollider : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private string nameScene;

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

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "Player")
    {
        SceneManager.LoadScene(nameScene);
    }
}

#endregion

}
