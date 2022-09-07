using UnityEngine;
using UnityEngine.UI;

public class CurrentLevelText : MonoBehaviour
{
    public Text CurrentLevel;
    public Game Game;

    private void Start()
    {
        CurrentLevel.text = (Game.LevelIndex + 1).ToString();
    }
}
