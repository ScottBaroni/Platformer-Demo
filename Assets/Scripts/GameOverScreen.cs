using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public GameObject player;
    public GameObject inGameUI;

    public void Setup(int totalScore)
    {
        inGameUI.SetActive(false);
        player.gameObject.GetComponent<PlayerController>().enabled = false;
        gameObject.SetActive(true);
        scoreTxt.text = "Score: " + totalScore.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Bookworming");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
