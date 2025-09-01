using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBase : MonoBehaviour
{
    public Vector2 velocity;
    public float gravityFactor;
    public float desiredx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 acceleration = 9.81f * Vector2.down * gravityFactor;
        velocity += acceleration * Time.fixedDeltaTime;

        velocity = desiredx;

        Movement(velocity * Time.fixedDeltaTime);
    }

    public void Movement(Vector2 move)
    {
        if (move.magnitude < 0.00001f) return;

        RaycastHit2D[] results = new RaycastHit2D[16];
        int cnt = GetComponent<Rigidbody2D>().Cast(move, results, move.magnitude + 0.001f);
        
        if (cnt > 0) return;

        transform.position += (Vector3) move;
    }
}
