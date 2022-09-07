using UnityEngine;
using UnityEngine.UI;

public class NextLevelText : MonoBehaviour
{
    public Text NextLevel;
    public Game Game;

    private void Start()
    {
        NextLevel.text = (Game.LevelIndex + 2).ToString();
    }
}
