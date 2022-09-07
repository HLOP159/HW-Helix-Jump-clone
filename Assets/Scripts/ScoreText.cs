using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int score = 0;
    private int highscore = 0;

    public Text Score;
    public Text HighScore;

    

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        Score.text = "SCORE: " + score.ToString();
        HighScore.text = "HIGHSCORE: " + highscore.ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) 
        {
            score++;
            Score.text = "Score: " + score.ToString();
            if (highscore < score)
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }    
    }
}
