using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public bool isGameOn = false;
    public ScoreManager scoreManager;
    public int playerScore = 0;
    public GameObject playButton;
    public GameObject mainMenuButton;
    public GameObject gameOver;
    public Text scoreText;

     
    [ContextMenu("AddScore")]
    public void AddScore(int scoreToAdd)
    {
        playerScore+=scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    void Start()
    {
        scoreManager = GameObject.Find("ScoreScript").GetComponent<ScoreManager>(); 
    }

    public void Awake()
    {
        playerScore = 0;
        isGameOn = true;
        scoreText.text = playerScore.ToString();

        mainMenuButton.SetActive(false);
        playButton.SetActive(false);
        gameOver.SetActive(false);
    }

    public void Restart()
    {
        isGameOn = true;
        mainMenuButton.SetActive(false);
        gameOver.SetActive(false);
        playButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        if(!isGameOn) {
            return; 
        }

        isGameOn = false;
        mainMenuButton.SetActive(true);
        gameOver.SetActive(true);
        playButton.SetActive(true);
        scoreManager.AddScore(playerScore);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }    
}
