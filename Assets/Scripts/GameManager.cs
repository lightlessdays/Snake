using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject StartGameGameObjects;
    [SerializeField] GameObject GameOverGameObjects;
    [SerializeField] GameObject PauseGameGameObjects;
    [SerializeField] GameObject ScoreTextFieldPaused;
    [SerializeField] GameObject ScoreTextFieldGameOver;

    private bool pauseMode ;
    private bool startMode ;
    private bool gameOverMode ;
    private bool gameMode; 

    int score = 0;

    public void IncreaseScore()
    {
        score++;
        ScoreTextFieldPaused.transform.GetComponent<TextMeshProUGUI>().text="Score: " + score;
        ScoreTextFieldGameOver.transform.GetComponent<TextMeshProUGUI>().SetText("SCORE: " + score);
    }

    private void Awake()
    {
           pauseMode = false;
     startMode = true;
     gameOverMode = false;
     gameMode = false;
    PauseGame();
        StartGameGameObjects.SetActive(true);
    }

    private void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.R) && startMode) {
            StartGameGameObjects.SetActive(false);
            ResumeGame();
            startMode = false;
                gameMode=true;
            }

        if (Input.GetKeyDown(KeyCode.P) && gameMode)
        {
            PauseGameGameObjects.SetActive(true);
            PauseGame();
            pauseMode = true;
            gameMode = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && pauseMode)
        {
            PauseGameGameObjects.SetActive(false);
            ResumeGame();
            pauseMode = false;
            gameMode = true;
        }

        

    }

    private void PauseGame()
    {
        Time.timeScale = 0;

    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void KillSnake()
    {
        PauseGame();
        GameOverGameObjects.SetActive(true);
    }
}
