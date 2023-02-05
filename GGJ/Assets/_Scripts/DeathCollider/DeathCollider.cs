using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private Transform startPosition;
[SerializeField] private List<GameObject> iceList;
[SerializeField] private bool reactive = false;

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
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.gameObject.transform.position = startPosition.position;

        if (reactive)
        {
            ReactiveIceList();
        }
    }
}

private void ReactiveIceList()
{
    foreach (var iceObject in iceList)
    {
        iceObject.SetActive(true);
        iceObject.GetComponent<IceComponent>().ResetTimes();
    }
}

#endregion

}
