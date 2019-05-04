using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float velo;
    private Rigidbody _body;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        velo = _body.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {

        velo = _body.velocity.magnitude;

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroyer Collision");

        Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
        Debug.Log(velo);
        if (collision.gameObject.GetComponent<Destroyable>() == null) return;
        collision.gameObject.GetComponent<Destroyable>().handleDestroyerCollision(this.gameObject);
    }
}
