using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigidbody;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
