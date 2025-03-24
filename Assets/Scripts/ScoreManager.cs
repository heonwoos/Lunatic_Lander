using TMPro;
using Unity.VisualScripting;
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
       UpdateScores(0);
    }

    public void UpdateScores(int stage) {
        SetCurrentScore(stage);
        SetHighScore(stage);
        DisplayScores();
    }

    public bool IsScored(int stage) {
        return currentScore == stage - 1;
    }
    private void SetCurrentScore(int stage) {
        currentScore = stage;
    }
    private void SetHighScore(int stage) {
        if (highScore < stage) {
            PlayerPrefs.SetInt("High", stage);
            highScore = PlayerPrefs.GetInt("High");
        }
    }
    private void DisplayScores() {
        currentScoreText.text = currentScore.ToString();
        highScoreText.text = highScore.ToString();
    }
}
