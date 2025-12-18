using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyFactory> enemyFactories = new List<EnemyFactory>();
    [SerializeField] Transform player;
    EnemyFactory enemyFactory;

    public void spawnEnemy()
    {
        enemyFactory = enemyFactories[Random.Range(0, enemyFactories.Count)];

        IEnemy enemy = enemyFactory.getEnemy();
        enemy.Player = player;

        Vector3 direction = new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y);
        direction = direction.normalized * Random.Range(20, 20);
        Vector3 position = transform.position + direction;

        enemy.positionAndRotation(position, Quaternion.identity);
        Health enemyHP = enemy.EnemyHP;
        //enemyHP.spawnOnDeath.AddListener(_ => GetComponent<ItemSpawner>().spawnRandomItems());
    }

    private void OnSpawn()
    {
        spawnEnemy();
    }
}
