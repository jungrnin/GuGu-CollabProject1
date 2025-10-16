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
    public GameObject anyKeyUI;

    private int score = 0;
    private bool isGameOver = false;
    private bool isGameStarted = false;

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
        scoreText.gameObject.SetActive(false);
        anyKeyUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if(!isGameStarted && Input.anyKeyDown)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        isGameStarted = true;
        anyKeyUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
    public void AddScore(int amount)
    {
        if(isGameOver || !isGameStarted)
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
        Time.timeScale = 0f;
        
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
