using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenLog : MonoBehaviour
{
    float durata = 10;
    Vector3 destinazione = new Vector3(0f,0f,10f);

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.move(this.gameObject, destinazione, durata);
        StartCoroutine(RemoveLog());
    }
    
    IEnumerator RemoveLog(){
        yield return new WaitForSeconds(durata); 
        Destroy(this.gameObject); 
    }
}
