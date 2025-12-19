using UnityEngine;

public class Enemy1Factory : EnemyFactory
{
    [SerializeField] GameObject enemyPrefab;

    public override IEnemy getEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);

        return enemy.GetComponent<RangedEnemy>();
    }
}
