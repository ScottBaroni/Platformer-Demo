using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsBase
{


    public float fasterDescentGrav = 2.0f;
    public float speed = 4.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0) desiredx = speed;
        else if (Input.GetAxis("Horizontal") < 0) desiredx = -speed;
        else desiredx = 0;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            if (powerJump)
            {
                velocity.y = 10f;
                powerJump = false;
            }
            else velocity.y = 6.5f;
        }

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !grounded)
        {
            velocity.y += -fasterDescentGrav * Time.deltaTime;
        }
    }

    public override void Collide(Collider2D other)
    {
        base.Collide(other);

        if (other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Collected powerup!");
            powerJump = true;
            other.gameObject.SetActive(false);
        }
    }

}
