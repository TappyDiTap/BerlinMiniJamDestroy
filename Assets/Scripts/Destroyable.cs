using System.Collections;
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
    //velocity factor
    public double velocityFactor = 1.0d;
    // Start is called before the first frame update
    public float disappearDelay = 0.2f;

    
    public void handleDestroyerCollision(GameObject destroyer){
        double destroyerVelocity = destroyer.GetComponent<Rigidbody>().velocity.magnitude;
        
        int damage = calculateDamage(destroyerVelocity);
        Debug.Log("velocity: " + destroyerVelocity);
        Debug.Log("damage dealt: " + damage);
        Debug.Log("old health: " + health);
        inflictDamage(damage);
    }

    void OnCollisionEnter(){
        Debug.Log("destroyable Collision");
    }
    
    int calculateDamage(double destroyerVelocity){
        double diff = (destroyerVelocity*velocityFactor) - velocityLimit;
        Debug.Log("velocity difference: " + diff);
        int damage = 0;
        if (diff > 0) damage = (int)(damageFactor*diff);
        return damage;
    }

    void inflictDamage(int damage){
        health -= damage;
        Debug.Log("new health: " + health);
        if (health <= 0) Destroy(this.gameObject, disappearDelay);
    }
}
