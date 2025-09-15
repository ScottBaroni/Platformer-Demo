using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickup : MonoBehaviour
{
    public PlayerMovement player;

    void Awake()
    {
        // Find the player in the scene
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected crumb!");
            player.UpdateScore();
            gameObject.SetActive(false);
        }
    }
}
