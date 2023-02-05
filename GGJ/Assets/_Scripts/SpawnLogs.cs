using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogs : MonoBehaviour
{
    [SerializeField] public int SpawnInterval = 5;
    [SerializeField] public int SpawnAmount = 2;
    [SerializeField] public Vector3 SpawnLocation;
    private int count = 0;
  
    public GameObject TreeLog;

    void OnEnable()
    {
        StartCoroutine(SpawnLog());
    }

    IEnumerator SpawnLog()
    {
        yield return new WaitForSeconds(SpawnInterval);
        Instantiate(TreeLog, SpawnLocation, Quaternion.identity);
        count++;
        if(count!=SpawnAmount)
            StartCoroutine(SpawnLog());
    }
}
