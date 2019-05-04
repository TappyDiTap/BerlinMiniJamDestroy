using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedStructure : MonoBehaviour
{
    public List<GameObject> connections = new List<GameObject>();
    // Start is called before the first frame update
    private Rigidbody rb;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogWarning("Rigidbody is null on object: " + this.gameObject.name);
            return;
        } 
        rb.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        clearNulls();
    }

    void FixedUpdate(){
        if (connections.Count <= 0){
            if (rb == null) {
                Debug.LogWarning("Rigidbody is null on object: " + this.gameObject.name);
                return;
            }
            rb.WakeUp();
        }
    }

    void clearNulls(){
        foreach(GameObject o in connections){
            if (o == null) connections.Remove(o);
        }
    }
}
