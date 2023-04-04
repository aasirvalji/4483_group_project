using System.Collections;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int gridWidth = 1;
    [SerializeField] private int gridHeight = 1;
    [SerializeField] private float cellSize = 1f;
    [SerializeField] private Vector2 gridOrigin = Vector2.zero;

    public void generateNextWave()
    {
        int enemiesToSpawn = GameObject.FindGameObjectWithTag("EnemySpawnerManager").GetComponent<LevelEnemies>().levelEnemyCount;
        for (int enemy = 1; enemy <= enemiesToSpawn; enemy++)
        {
            SpawnEnemyAtRandomPosition();
        }
    }

    public void SpawnEnemyAtRandomPosition()
    {
        int randomX = Random.Range(-1 * gridWidth, gridWidth);
        int randomY = Random.Range(-1 * gridHeight, gridHeight);

        Vector2 spawnPosition = gridOrigin + new Vector2(randomX * cellSize, randomY * cellSize);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void Start()
    {
        generateNextWave();
    }
}