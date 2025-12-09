using UnityEngine;

public class SlimeFactory : EnemyFactory
{
    [SerializeField] GameObject enemyPrefab;

    public override IEnemy getEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);

        return enemy.GetComponent<MeleeEnemy>();
    }
}
