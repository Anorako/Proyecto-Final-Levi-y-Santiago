using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public GameObject gameCompleted;

    [SerializeField]
    [Range(1,12)]
    public static int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " PUNTOS";
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " PUNTOS";
        Victory();
    }

    private void Victory()
    {
        if (score >= 12)
        {
            gameCompleted.SetActive(true);
        }
    }
}
