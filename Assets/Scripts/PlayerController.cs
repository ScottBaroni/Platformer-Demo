using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : PhysicsBase
{


    public float fasterDescentGrav = 2.0f;
    public float speed = 4.5f;
    public GameOverScreen gameOverScreen;
    public int lives = 3;
    public int score = 0;
    public TextMeshProUGUI currScore;
    //public PowerupRespawn powerupRespawn;

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
        if (other.gameObject.CompareTag("Lethal"))
        {
            GameOver();
        }

        if (other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Collected powerup!");
            powerJump = true;
            other.GetComponentInParent<PowerupRespawn>().Collected();
        }

        if (other.gameObject.CompareTag("Collectable"))
        {
            Debug.Log("Collected crumb!");
            other.gameObject.SetActive(false);
            UpdateScore();
        }
    }

    public void GameOver()
    {
        gameOverScreen.Setup(score);
    }

    public void UpdateScore()
    {
        score++;
        currScore.text = "Score: " + score;
    }

}
