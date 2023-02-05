using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceComponent : MonoBehaviour
{

#region Variables & Properties

[SerializeField] private float time;
[SerializeField] private int timeBeforePlatformIsDestroyed;
private int copyTimes;

#endregion

#region MonoBehaviour

    // Awake is called when the script instance is being loaded
    void Awake()
    {
	
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetTimes();
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
        switch (copyTimes)
        {
            case 0:
                break;
            case 1:
                StartCoroutine(TimerDeactive());
                break;
            case 2:
                copyTimes--;
                break;
        }
    }
}

public void ResetTimes()
{
    copyTimes = timeBeforePlatformIsDestroyed;
}

private IEnumerator TimerDeactive()
{
    yield return new WaitForSeconds(time);
    gameObject.SetActive(false);
}

#endregion

}
