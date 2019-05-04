using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    // does the character accept input?
    public bool active = true;

    public float speedX = 1.0f;
    public float jumpStrength = 5.0f;
    // jump check min and max
    public float xBoundingBox = 1.0f;
    public float yBoundingBox = 1.0f;

    private Rigidbody body;
    private bool jumpInput = false;
    private float xInput = 0.0f;
    private Vector3 xOffsetBodyVector;
    private Vector3 yOffsetBodyVector;

    // Start is called before the first frame update
    void Start() {
        body = transform.GetComponent<Rigidbody>();
        xOffsetBodyVector = new Vector3(xBoundingBox, 0.0f, 0.0f);
        yOffsetBodyVector = new Vector3(0.0f, yBoundingBox, 0.0f);
    }

    void Update() {
        // save inputs
        if(Input.GetButton("Jump") && jumpInput == false) {
            jumpInput = true;
            print("Hello");
        }
        xInput = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate() {
        // react to inputs
        // going into a direction
        if(xInput != 0.0f && sideFree(Mathf.Sign(xInput) == 1)) {
            body.velocity = new Vector3(xInput * speedX, body.velocity.y, 0.0f);
        }

        // jumping
        if(jumpInput && IsStanding()) {
            body.velocity += new Vector3(0.0f, jumpStrength, 0.0f);
        }
        jumpInput = false;
    }

    public bool IsStanding() {
        // if obj is moving up or down
        if(body.velocity.y >= 0.01f) {
            return false;
        }

        if(!RaycastHit(xOffsetBodyVector, Vector3.down, yBoundingBox) && !RaycastHit(-xOffsetBodyVector, Vector3.down, yBoundingBox)) return false;
        return true;
    }

    public bool sideFree(bool right) {
        Vector3 direction = Vector3.right;
        if(!right) {
            direction = -direction;
        }

        if(RaycastHit(yOffsetBodyVector, direction, xBoundingBox) || RaycastHit(-yOffsetBodyVector, direction, xBoundingBox)) return false;
        return true;
    }

    private bool RaycastHit(Vector3 offset, Vector3 direction, float distance) {
        RaycastHit hitinfo;
        return Physics.Raycast(body.transform.position + offset, direction, out hitinfo, distance);
    }
}
