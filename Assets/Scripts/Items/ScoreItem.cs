using NUnit.Framework;
using UnityEngine;

public class ScoreItem : MonoBehaviour, IItem
{
    [SerializeField] private int scoreAmount = 10;
    public void Use(Collider player)
    {
        var score = player.GetComponent<PlayerScore>();
        if (score != null) score.AddScore(scoreAmount);
    }

    public string GetName()
    {
        return "Score Item";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Логика добавления очков игроку
            Debug.Log("Score Item Collected!");
            Use(other);
            Destroy(gameObject);
        }
    }
}
