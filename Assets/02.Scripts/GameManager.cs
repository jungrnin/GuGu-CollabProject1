using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public GameObject gameOverUI;

    private int score = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
        gameOverUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void AddScore(int amount)
    {
        if(isGameOver)
        {
            return;
        }
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = " " + score.ToString();
    }
    
    public void GameOver()
    {
        isGameOver = true;
        scoreText.gameObject.SetActive(false);
        gameOverUI.SetActive (true);
        finalScoreText.text = "Score : " + score.ToString();
        
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
