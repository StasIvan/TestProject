using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoSingleton<GameController>
{
    public Action OnStart;
    public Action OnVictory;
    public Action OnLose;

    private void Start()
    {
        OnStart?.Invoke();
    }

    private void OnEnable()
    {
        OnVictory += StopGame;
        OnLose += StopGame;
        OnStart += ContinueGame;
    }

    private void OnDisable()
    {
        OnVictory -= StopGame;
        OnStart -= ContinueGame;
        OnLose -= StopGame;
    }

    private void Init()
    {
        ContinueGame();
    }

    public void LevelEnd(bool playerWin)
    {
        if (playerWin)
        {
            OnVictory?.Invoke();
        }
        else
        {
            OnLose?.Invoke();
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }
}
