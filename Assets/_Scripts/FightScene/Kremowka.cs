﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kremowka : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 21.37f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
            Destroy(gameObject);
    }
}
