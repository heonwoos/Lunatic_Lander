using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore;
    private int highScore;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    void Start()
    {
       highScore = PlayerPrefs.GetInt("High", 0);
    }

    public void UpdateScores(int score) {
        SetCurrentScore(score);
        SetHighScore(score);
        DisplayScores();
    }

    private void SetCurrentScore(int score) {
        if (currentScore < score)
            currentScore = score;
    }
    private void SetHighScore(int score) {
        if (highScore < score)
            PlayerPrefs.SetInt("High", score);
            highScore = PlayerPrefs.GetInt("High");
    }

    private void DisplayScores() {
        currentScoreText.text = currentScore.ToString();
        highScoreText.text = highScore.ToString();
    }
}
