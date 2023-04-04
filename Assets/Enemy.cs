using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private SlimeSpawner slimeSpawner;
    private SceneTransition sceneTransition;
    Animator animator;
    public static int numberOfEnemies;
    public static int waveNum = 1;
    [SerializeField] private string nextScene;
    public float Health
    {
        set
        {
            health = value;

            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    public float health = 1;

    private void Start()
    {
        GameObject spawnerManager = GameObject.Find("EnemySpawnerManager");
        slimeSpawner = spawnerManager.GetComponent<SlimeSpawner>();

        GameObject transitionManager = GameObject.Find("SceneTransitionManager");
        sceneTransition = transitionManager.GetComponent<SceneTransition>();

        numberOfEnemies = GameObject.FindGameObjectWithTag("EnemySpawnerManager").GetComponent<LevelEnemies>().levelEnemyCount; 
        animator = GetComponent<Animator>();
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");

    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
        print("Before: " + numberOfEnemies);
        numberOfEnemies--;
        print("After: " + numberOfEnemies);
        if (numberOfEnemies == 0 && waveNum == 3)
        {
            Debug.Log("All enemies destroyed!");
            waveNum = 1;
            sceneTransition.FadeToLevel(nextScene);
        } else if (numberOfEnemies == 0)
        {
            Debug.Log("Wave passed");
            waveNum = waveNum + 1;
            slimeSpawner.generateNextWave();
        }
    }
}
