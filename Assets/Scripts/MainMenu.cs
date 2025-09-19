using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;
    public void StartButton()
    {
        SceneManager.LoadScene("Bookworming");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void CreditsButton()
    {
        if (credits != null)
            {
                credits.SetActive(!credits.activeSelf);
            }
    }
}
