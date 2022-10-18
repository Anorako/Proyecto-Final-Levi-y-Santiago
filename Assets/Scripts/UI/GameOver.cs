using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text pointsText;
    public void Setup (int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " PUNTOS"; 
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreManager.score = 0;
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
