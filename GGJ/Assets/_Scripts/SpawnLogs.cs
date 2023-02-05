using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogs : MonoBehaviour
{
    [SerializeField] public int SpawnInterval = 5;
    [SerializeField] public Vector3 SpawnLocation;
  
    public GameObject TreeLog;
    // Start is called before the first frame update


    void OnEnable()
    {
        StartCoroutine(SpawnLog());
    }

    IEnumerator SpawnLog()
    {
        yield return new WaitForSeconds(SpawnInterval);
        Instantiate(TreeLog, SpawnLocation, Quaternion.identity);
        //Instantiate(TreeLog, Spawn2, Quaternion.identity);
        //Instantiate(TreeLog, Spawn3, Quaternion.identity);
        StartCoroutine(SpawnLog());
    }
}
