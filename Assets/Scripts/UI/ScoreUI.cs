using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;

    public void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + score.ToString();
    }
}
