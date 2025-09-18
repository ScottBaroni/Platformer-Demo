using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickup : MonoBehaviour
{
    public PlayerMovement player;
    AudioManager audioManager;

    void Awake()
    {
        // Find the player in the scene
        player = FindObjectOfType<PlayerMovement>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Play sound
            audioManager.playSFX(audioManager.collectSFX);
            Debug.Log("Collected crumb!");
            player.UpdateScore();
            gameObject.SetActive(false);
        }
    }
}
