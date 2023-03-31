using System.Collections;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int gridWidth = 1;
    [SerializeField] private int gridHeight = 1;
    [SerializeField] private float cellSize = 1f;
    [SerializeField] private Vector2 gridOrigin = Vector2.zero;

    private void Start()
    {
        SpawnEnemyAtRandomPosition();
    }

    private void SpawnEnemyAtRandomPosition()
    {
        int randomX = Random.Range(0, gridWidth);
        int randomY = Random.Range(0, gridHeight);

        Vector2 spawnPosition = gridOrigin + new Vector2(randomX * cellSize, randomY * cellSize);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}