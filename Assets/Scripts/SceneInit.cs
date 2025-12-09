using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SceneInit : MonoBehaviour
{
    [SerializeField] private Spawner spawnerScript;
    [SerializeField] private NavmeshGenerator navmeshGeneratorScript;
    [SerializeField] private GameObject enemyObjectPrefab;
    [SerializeField] private Spawner enemySpawnerScript;
    [SerializeField] private int enemyCount = 5;

    public void Start()
    {
        spawnerScript.GenerateMaze();
        StartCoroutine(NavMeshCoroutine(2f));
        StartCoroutine(EnemySpawnewrCoroutine(3f));
    }

    private IEnumerator NavMeshCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        navmeshGeneratorScript.BuildNavMesh();
    }

    private IEnumerator EnemySpawnewrCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int Width = spawnerScript.Width;
        int Height = spawnerScript.Height;
        float cellSize = spawnerScript.CellSize.x;

        int randX = Random.Range(0, Width - 1);
        int randY = Random.Range(0, Height - 1);

        Vector3 pos = new Vector3(
            randX * cellSize + cellSize * 0.5f,
            0f,
            randY * cellSize + cellSize * 0.5f
        );

        NavMeshHit hit;
        if (NavMesh.SamplePosition(pos, out hit, cellSize * 0.4f, NavMesh.AllAreas))
        {
            Instantiate(enemyObjectPrefab, hit.position, Quaternion.identity);
        }
        else
        {
            SpawnEnemy();
        }
    }
}
