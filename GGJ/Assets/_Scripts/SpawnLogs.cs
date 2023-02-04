using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogs : MonoBehaviour
{

    public GameObject TreeLog;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(TreeLog, new Vector3(0f, 0f, 0f), Quaternion.identity);
        StartCoroutine(SpawnLog());
    }

    IEnumerator SpawnLog()
    {
        yield return new WaitForSeconds(5);
        Instantiate(TreeLog, new Vector3(0f, 0f, 0f),Quaternion.identity);
        StartCoroutine(SpawnLog());
    }
}
