using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] UIManager uiManager;

    public void PlayerWin()
    {
        uiManager.YouWin();
        gameManager.TimeUp();
    }
}