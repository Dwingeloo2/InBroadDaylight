﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float thrust = 90.0F;
    public float acceleration = 1.0f;
    public float maxVelocity = 5.0f; // This doesn't do anything yet
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
        AffectHealth(regenRate);
	}
    
    
    void Propel()
    {
        float propel = Input.GetAxis("Vertical") * thrust;
        if (propel >= 0)
        {
            propel *= Time.deltaTime * acceleration;
            rb.AddRelativeForce(Vector3.up * propel);
        }
    }

    void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, rotation);
    }


    public float maxHealth = 100;
    public float health = 50;
    public float regenRate = 0.05f;
    public void AffectHealth(float amount)
    {
        if (amount > 0) {
            if (health < maxHealth)
            {
                health += amount;
            }
        } else
        {
            if (health > 0)
            {
                health += amount;
            } else
            {
                Die();
            }
        }
    }


    public void Die()
    {
        Debug.Log("Ye dead");
    }
}
