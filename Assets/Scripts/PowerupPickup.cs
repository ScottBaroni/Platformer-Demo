using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPickup : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play sound
            audioManager.playSFX(audioManager.powerupSFX);

            // Apply effect to player here
            Debug.Log("Player got powerup!");
            other.GetComponent<PlayerMovement>().powerJump = true;

            // Tell parent to handle respawn
            GetComponentInParent<PowerupRespawn>().Collected();
        }
    }
}
