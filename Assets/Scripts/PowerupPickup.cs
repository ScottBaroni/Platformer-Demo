using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Tell parent to handle respawn
            GetComponentInParent<PowerupRespawn>().Collected();

            // Apply effect to player here
            Debug.Log("Player got powerup!");
            other.GetComponent<PlayerController>().powerJump = true;
        }
    }
}
