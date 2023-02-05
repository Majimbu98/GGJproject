using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenLog : MonoBehaviour
{
    public Vector3 destinazione = new Vector3(0f,0f,10f);
    public Vector3 origine = new Vector3(0f, 0f, 0f);
    public float durata = 10;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(MoveLog());
    }
    
    IEnumerator MoveLog(){
        while(true){
            LeanTween.move(this.gameObject, destinazione, durata);
            yield return new WaitForSeconds(durata);
            transform.position = origine;
        }
    }
}
