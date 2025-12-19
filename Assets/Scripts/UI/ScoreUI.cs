using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int AddScore)
    {
        this.score += AddScore;
        scoreText.text = "Score: " + score.ToString();
    }
}
