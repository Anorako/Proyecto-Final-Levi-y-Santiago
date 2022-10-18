using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Juego cerrado");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
        ScoreManager.score = 0;
    }
}
