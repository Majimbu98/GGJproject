using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogs : MonoBehaviour
{
    [SerializeField] public int SpawnInterval = 5;
    [SerializeField] public int SpawnAmount = 2;
    [SerializeField] public Vector3 SpawnLocation;
    [SerializeField] public Vector3 ArrivalLocation;
    [SerializeField] public int TravelDuration;
    private int count = 0;
  
    public WoodenLog TreeLog;

    void OnEnable()
    {
        StartCoroutine(SpawnLog());
    }

    IEnumerator SpawnLog()
    {
        TreeLog.origine = SpawnLocation;
        TreeLog.destinazione = ArrivalLocation;
        TreeLog.durata = TravelDuration;
        yield return new WaitForSeconds(SpawnInterval);
        Instantiate(TreeLog, SpawnLocation, Quaternion.identity);
        //current.origine = SpawnLocation;
        //current.destinazione = ArrivalLocation;
        count++;
        if(count!=SpawnAmount)
            StartCoroutine(SpawnLog());
    }
}
