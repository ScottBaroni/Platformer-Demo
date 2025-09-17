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
    public TextMeshProUGUI totalScoreTxt;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI timeBonTxt;
    public int score;
    public int totalTime;
    public int timeBonus = 0;
    public int targetTime = 60;
    public int bonusMult = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Setup();
        }
    }

    private void Setup()
    {
        winUI.SetActive(true);
        stopwatch.StopStopwatch();
        inGameUI.SetActive(false);
        score = player.GetScore();
        totalTime = stopwatch.getTime();
        timeTxt.text = "Total Time: " + totalTime + "s";

        // Calculate time bonus
        timeBonus = Math.Max(0, targetTime - totalTime) * bonusMult;
        timeBonTxt.text = "Time Bonus: " + timeBonus;

        totalScoreTxt.text = "Score: " + (score + timeBonus);
    }
}
