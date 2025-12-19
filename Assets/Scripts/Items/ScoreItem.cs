using NUnit.Framework;
using UnityEngine;

public class ScoreItem : MonoBehaviour, IItem
{
    [SerializeField] private int scoreAmount = 10;
    [SerializeField] private GameObject obj;

    public void Use(Collider player)
    {
        var score = FindFirstObjectByType<ScoreUI>();
        score.UpdateScore(scoreAmount);
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

    public void SpawnItem(Vector3 pos)
    {
        Instantiate(obj, pos, Quaternion.identity);
    }
}
