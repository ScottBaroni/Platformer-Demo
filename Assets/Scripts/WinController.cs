using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class WinController : MonoBehaviour
{
    public GameObject winUI;
    public GameObject inGameUI;
    public PlayerMovement player;
    public Stopwatch stopwatch;
    public AudioManager audioManager;
    public TextMeshProUGUI totalScoreTxt;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI timeBonTxt;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI crumbBonTxt;
    public int timeBonus = 0;
    public int targetTime = 180;
    public int bonusMult = 5;
    public int crumbMult = 2;
    int crumbBonus;
    int score;
    int totalTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Setup();
        }
    }

    private void Setup()
    {
        // Change music
        audioManager.switchMusic();

        // Change UI
        winUI.SetActive(true);
        stopwatch.StopStopwatch();
        inGameUI.SetActive(false);

        // Get time and score
        score = player.GetScore();
        totalTime = stopwatch.getTime();
        timeTxt.text = "Total Time: " + totalTime + "s";
        scoreTxt.text = "Crumbs Collected: " + score;

        // Calculate time and crumb bonus and total score
        timeBonus = Math.Max(0, targetTime - totalTime) * bonusMult;
        crumbBonus = score * crumbMult;
        timeBonTxt.text = "Time Bonus: " + timeBonus;
        crumbBonTxt.text = "Crumb Bonus: " + crumbBonus;
        totalScoreTxt.text = "Total Score: " + (crumbBonus + timeBonus);
    }
}
