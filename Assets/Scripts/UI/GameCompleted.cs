using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCompleted : MonoBehaviour
{
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
