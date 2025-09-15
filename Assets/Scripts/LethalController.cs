using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LethalController : MonoBehaviour
{
    public PlayerMovement player;

    void Awake()
    {
        // Find the player in the scene
        player = FindObjectOfType<PlayerMovement>();
    }

    public void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player"))
        {
            player.DisplayGameOver();
        }
    }
}
