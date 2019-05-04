﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    //the velocity limit when the destroyer starts to deal damage to the destrocable object
    public double velocityLimit = 10.0d;
    //health of the object, if 0 the object will be destroyed
    public int health = 10;
    //factor for damage calculation
    public double damageFactor = 10.0d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleDestroyerCollision(GameObject destroyer){
        double destroyerVelocity = destroyer.GetComponent<Rigidbody>().velocity.y;
        
        int damage = calculateDamage(destroyerVelocity);
        Debug.Log("velocity: " + destroyerVelocity);
        Debug.Log("damage dealt: " + damage);
        Debug.Log("old health: " + health);
        inflictDamage(damage);
    }

    int calculateDamage(double destroyerVelocity){
        double diff = destroyerVelocity - velocityLimit;
        int damage = 0;
        if (diff > 0) damage = (int)(damageFactor*diff);
        return damage;
    }

    void inflictDamage(int damage){
        health -= damage;
        Debug.Log("new health: " + health);
        if (health <= 0) Destroy(this.gameObject);
    }
}
