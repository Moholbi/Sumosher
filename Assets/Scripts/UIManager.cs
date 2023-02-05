using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    bool timeUp = false;

    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject startButton;
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI enemyNumberUI;
    [SerializeField] TextMeshProUGUI timerUI;
    [SerializeField] GameObject youWinScreen;
    [SerializeField] float gameTimer = 60f;

    bool started = false;

    void Awake()
    {
        startButton.SetActive(true);
    }

    void Update()
    {
        SetTimerText();
        StartTimer();
    }

    public void StartTimer()
    {
        if (!timeUp && (Input.anyKeyDown))
        {
            started = true;
        }
    }

    public void SetTimerText()
    {
        if (started)
        {
            gameTimer -= Time.deltaTime;
            timerUI.text = gameTimer.ToString("0");
            if (gameTimer <= 0)
            {
                timeUp = true;
                gameManager.TimeUp();
            }
        }
    }

    public void SetScoreText(int score)
    {
        scoreUI.text = score.ToString();
    }

    public void SetAliveCountText()
    {
        enemyNumberUI.text = GameManager.EatersList.Count.ToString();
    }

    public void StartLevel()
    {
        gameManager.MoveStopEaters(true);
        startButton.SetActive(false);
    }

    public void YouWin()
    {
        youWinScreen.SetActive(true);
    }
}