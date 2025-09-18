using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;
    public float speed;
    public float jump;
    public float fasterDescentGrav = 5.0f;
    public float defaultGravity = 1.0f;
    public int score = 0;
    public TextMeshProUGUI currScore;
    public Boolean powerJump = false;
    public float powerJumpMod = 4.0f;

    public Boolean isGrounded = true;
    public float groundCheckRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public GameOverScreen gameOverScreen;
    AudioManager audioManager;

    Animator animator;
    Boolean facingRight = true;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        if (move < 0 && facingRight)
        {
            Flip();
        }

        // Checking if on ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Play jump sfx
            audioManager.playSFX(audioManager.jumpSFX);
            if (powerJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump * powerJumpMod);
                powerJump = false;
            }
            else rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        // Faster descent
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !isGrounded)
        {
            rb.gravityScale = defaultGravity * fasterDescentGrav;
        }
        else
        {
            rb.gravityScale = defaultGravity;
        }
    }

    // Flip the sprite for walking
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    public void DisplayGameOver()
    {
        // Play death sound
        audioManager.playSFX(audioManager.deathSFX);
        gameOverScreen.Setup(score);
    }

    public void UpdateScore()
    {
        score++;
        currScore.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}
