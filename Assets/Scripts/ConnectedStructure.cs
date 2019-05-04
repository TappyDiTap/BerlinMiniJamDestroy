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
      //  rb.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate(){
        clearNulls();
        if (connections.Count <= 0)
        {
            Debug.Log(connections.Count);
            print("AHHHHHHHHH");
            if (rb == null) {
                Debug.LogWarning("Rigidbody is null on object: " + this.gameObject.name);
                return;
            }
            //  rb.WakeUp();
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                }
    }

    void clearNulls(){
        List<GameObject> list = new List<GameObject>();
        list.AddRange(connections);
        foreach(GameObject o in list){
            if (o == null) connections.Remove(o);
        }
    }
}
