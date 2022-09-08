using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls Controls;
    public float InvokeTime = 0;

    private void Start()
    {
        gameObject.GetComponent<AudioSource>().enabled = true; // включает компонент аудиосорс, с главной музыкой
    }

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
        gameObject.GetComponent<AudioSource>().enabled = false; // отключение компонента аудиосорс, что выелючает музыку
        Invoke("ReloadLevel", InvokeTime);
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Plaing) return;

        CurrentState= State.Won;
        Controls.enabled = false;
        LevelIndex++;
        Debug.Log("You won!");
        gameObject.GetComponent<AudioSource>().enabled = false; // отключение компонента аудиосорс, что выелючает музыку
        Invoke("ReloadLevel", InvokeTime);
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
