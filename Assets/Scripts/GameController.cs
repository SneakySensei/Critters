using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool isGameRunning;
    public static bool isGameOver;
    public static int score;

    public Text MenuText;
    public Text GameOverText;
    public Text ScoreText;
    public Text HighScoreText;

    private AudioSource ambience;
    private int highScore;

    void Awake()
    {
        // Pause the game
        Time.timeScale = 0;
        isGameRunning = false;
        isGameOver = false;

        score = 0;
        ambience = GetComponent<AudioSource>();

        // Get saved highscore
        highScore = PlayerPrefs.GetInt("highscore", 0);
        HighScoreText.text = "Highscore: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = isGameRunning || isGameOver ? 1 : 0;
        MenuText.enabled = !isGameRunning && !isGameOver;
        GameOverText.enabled = !isGameRunning && isGameOver;
        ScoreText.enabled = isGameRunning || isGameOver;
        ambience.enabled = !isGameOver;

        if (!isGameRunning && !isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Start Game
                isGameRunning = true;
            }
        }

        if (isGameRunning || isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Restart Game
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        if (isGameRunning)
        {
            ScoreText.text = "Score: " + score;
            if (score > highScore)
            {
                HighScoreText.text = "Highscore: " + score;
            }
        }

        score = (int) Time.timeSinceLevelLoad;
    }

    public static void handleGameOver()
    {
        isGameRunning = false;
        isGameOver = true;

        if(score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
