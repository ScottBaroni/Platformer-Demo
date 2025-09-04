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
        Vector2 move = velocity * Time.fixedDeltaTime;
        Movement(new Vector2(move.x, 0), true);
        Movement(new Vector2(0, move.y), false);
    }

    public void Movement(Vector2 move, Boolean movex)
    {
        if (move.magnitude < 0.00001f) return;

        RaycastHit2D[] results = new RaycastHit2D[16];
        grounded = false;
        int cnt = GetComponent<Rigidbody2D>().Cast(move, results, move.magnitude + 0.001f);
        bool collision = false;

        for (int i = 0; i < cnt; i++)
        {
            if (Mathf.Abs(results[i].normal.x) > 0.5 && movex)
            {
                collision = true;
                CollideHorizontal(results[i].collider);
            }

            if (Mathf.Abs(results[i].normal.y) > 0.5 && !movex)
            {
                if (results[i].normal.y > 0.3f) grounded = true;
                collision = true;
                CollideVertical(results[i].collider);
            }
        }
        if (collision) return;
        transform.position += (Vector3)move;
    }

    public void Collide(Collider2D other)
    {
        if (other.gameObject.CompareTag("Lethal"))
        {
            Debug.Log("RIP");
        }
    }

    public virtual void CollideHorizontal(Collider2D other)
    {
        Collide(other);
    }
    
    public virtual void CollideVertical(Collider2D other)
    {
        Collide(other);
    }
}
