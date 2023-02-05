using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static EatingFood Leader;
    public static List<Transform> EatersList;

    [SerializeField] EnemyMovement[] enemyMovements;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] EatingFood[] eaters;
    [SerializeField] LeaderCrown leaderCrown;
    [SerializeField] UIManager UIManager;
    [SerializeField] WinScreen winScreen;

    void Awake()
    {
        EatersList = new List<Transform>();
        for (int i = 0; i < eaters.Length; i++)
        {
            EatersList.Add(eaters[i].transform);
        }
        UIManager.SetAliveCountText();
    }

    public void DecideLeader()
    {
        int maxScore = 0;
        int leaderIndex = 0;
        bool equalLeaders = false;

        for (int i = 0; i < eaters.Length; i++)
        {
            if (eaters[i].sushiScore >= maxScore)
            {
                if (eaters[i].sushiScore == maxScore)
                {
                    equalLeaders = true;
                }
                else
                {
                    maxScore = eaters[i].sushiScore;
                    leaderIndex = i;
                    equalLeaders = false;
                }
            }
        }

        Leader = eaters[leaderIndex];

        if (equalLeaders) leaderCrown.TurnOffCrown();
        else leaderCrown.LocateCrown();

        UIManager.SetScoreText(eaters[0].sushiScore);
    }

    public void MoveStopEaters(bool playing)
    {
        for (int i = 0; i < enemyMovements.Length; i++)
        {
            enemyMovements[i].StartStopRun(playing);
        }
        playerMovement.StartStopRun(playing);
    }

    public void GameOver()
    {
        MoveStopEaters(false);
        SceneManager.LoadScene(0);
    }

    public void EaterDied(Transform tr)
    {
        EatersList.Remove(tr);
        UIManager.SetAliveCountText();

        if (EatersList.Count == 1)
        {
            winScreen.PlayerWin();
        }
    }

    public void TimeUp()
    {
        MoveStopEaters(false);
    }
}