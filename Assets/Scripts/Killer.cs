﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        print("Hello");
        if (collision.gameObject.tag != "Player") return;
        collision.gameObject.GetComponent<Character2>().Kill();
    }
}
