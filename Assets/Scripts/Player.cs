using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
   
    public float thrust = 90.0F;
    public float acceleration = 1.0f;
    public float maxVelocity = 30.0f;
    public Vector3 velocity;
    public float rotationSpeed = 200.0F;
    private Rigidbody rb;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Propel();
        Rotate();
	}
    
    
    void Propel()
    {
        float propel = Input.GetAxis("Vertical") * thrust;
        if (propel >= 0)
        {
            propel *= Time.deltaTime * acceleration;
            rb.AddRelativeForce(Vector3.up * propel);
        }
        velocity = rb.velocity;
    }

    void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, rotation);
    }
}
