using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBase : MonoBehaviour
{
    public Vector2 velocity;
    public float gravityFactor;
    public float desiredx;

    public Boolean grounded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 acceleration = 9.81f * Vector2.down * gravityFactor;
        velocity += acceleration * Time.fixedDeltaTime;

        velocity.x = desiredx;

        Vector2 movement = velocity * Time.fixedDeltaTime;
        Movement(new Vector2(movement.x, 0), true);
        Movement(new Vector2(0, movement.y), false);
    }

    public void Movement(Vector2 move, Boolean movex)
    {
        if (move.magnitude < 0.00001f) return;

        RaycastHit2D[] results = new RaycastHit2D[16];
        int cnt = GetComponent<Rigidbody2D>().Cast(move, results, move.magnitude + 0.001f);

        if (cnt > 0)
        {
            grounded = true;
            return;
        }
        else
        {
            grounded = false;
        }
        transform.position += (Vector3)move;

        for (int i = 0; i < cnt; i++)
        {
            if (Mathf.Abs(results[i].normal.x) > 0.5 && movex)
            {
                move.x = 0;
                velocity.x = 0;
                CollideWithHorizontal(results[i].collider);
            }

            if (Mathf.Abs(results[i].normal.y) > 0.5 && !movex)
            {
                move.y = 0;
                velocity.y = 0;
                CollideWithVertical(results[i].collider);
            }
        }

    }

    public virtual void CollideWithHorizontal(Collider2D other)
    {

    }
    
    public virtual void CollideWithVertical(Collider2D other)
    {
        
    }
}
