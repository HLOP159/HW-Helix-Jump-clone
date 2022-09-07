using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls Controls;


    public enum State
    {
        Plaing,
        Won,
        Lose
    }
    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Plaing) return;

        CurrentState = State.Lose;
        Controls.enabled = false;
        Debug.Log("game over");
        ReloadLevel();
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Plaing) return;

        CurrentState= State.Won;
        Controls.enabled = false;
        LevelIndex++;
        Debug.Log("You won!");
        ReloadLevel();
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
