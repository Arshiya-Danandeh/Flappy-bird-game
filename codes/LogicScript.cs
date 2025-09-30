using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;   
public class LogicScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    public GameObject gameOverScreen;
    private int highScore = 0;
    private int playerScore = 0;
    private int nextSpeedIncreaseScore = 5;
    public static float currentPipeSpeed = 3f;


    void Start()
    {
        // Reset static values for a new game
        currentPipeSpeed = 3f;
        PipeSpawnScript.spawnRate = 4f; // Use your intended default
        BirdScript.birdIsAlive = true;

        // Load high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;

        // Initialize score
        scoreText.text = "0";
    }

    public void addScore(int addToScore)
    {
        if (BirdScript.birdIsAlive)
        {
            playerScore = playerScore + addToScore;
            scoreText.text = playerScore.ToString();
        }

        //update score if beaten
        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = "High Score: " + highScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        if (playerScore >= nextSpeedIncreaseScore && playerScore <= 15)
        {
            Debug.Log(playerScore + " points reached, increasing pipe speed");

            // Increase overall pipe speed once
            currentPipeSpeed += 1f;

            // Set spawnRate so the gap between pipes stays the same
            // For example, keep a constant gap of 12 units between pipes:
            float desiredGap = 12f;
            float minSpawnRate = 1.2f; // Adjust this to your preferred minimum gap in seconds
            PipeSpawnScript.spawnRate = Mathf.Max(minSpawnRate, desiredGap / currentPipeSpeed);
            Debug.Log("New spawnRate: " + PipeSpawnScript.spawnRate);


            nextSpeedIncreaseScore = nextSpeedIncreaseScore + 5; // Set next threshold
        }
    }

    public void reastartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        
    }
   
}

