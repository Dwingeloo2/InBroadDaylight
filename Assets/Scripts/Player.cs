using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float thrust = 500.0f;
    public float maxVelocity = 5.0f;
    public float torque = 100.0f;
	public float maxAngularVelocity = 5.0f;
    private Rigidbody rb;
	public Image healthBar;
	public EndOfLevel levelEnder;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
		rb.maxAngularVelocity = maxAngularVelocity;
    }
	
	// Update is called once per frame
	void Update () {
        Propel();
        Rotate();

		CapVelocity ();

        AffectHealth(regenRate);
        UpdateHealthBar();
	}

	void CapVelocity() {
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxVelocity);
	}
    
    
    void Propel()
    {
        float propel = Input.GetAxis("Vertical") * thrust * Time.deltaTime;
        if (propel >= 0)
        {
            rb.AddRelativeForce(Vector3.up * propel);
        }
    }

    void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal") * torque * Time.deltaTime;
		rb.AddRelativeTorque (Vector3.forward * rotation);
        //rotation *= Time.deltaTime;
        //transform.Rotate(0, 0, rotation);
    }


    public float maxHealth = 100;
    public float health = 50;
    public float regenRate = 0.05f;
    public void AffectHealth(float amount)
    {
        UpdatePlayerIcon(amount);
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



    public Sprite playerIconGood;
    public Sprite playerIconWorried;
    public Sprite playerIconTerrified;
    void UpdatePlayerIcon(float amt)
    {
        if (Time.time < endHappyTime)
        {
            return;
        }
        Image icon = GameObject.Find("PlayerImage").GetComponent<Image>();
        if (amt > -0.1)
        {
            icon.sprite = playerIconGood;
        }
        else if (amt > -0.2)
        {
            icon.sprite = playerIconWorried;
        } else
        {
            icon.sprite = playerIconTerrified;
        }
    }
    
    private float endHappyTime = 0;
    public Sprite playerIconHappy;
    public void SetHappy(float length)
    {
        Image icon = GameObject.Find("PlayerImage").GetComponent<Image>();
        icon.sprite = playerIconHappy;
        endHappyTime = Time.time + length;
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = health / maxHealth;
    }


    public void Die()
    {
        health = -1;
        Debug.Log("Ye dead");
		levelEnder.End (gameObject);
    }

}
