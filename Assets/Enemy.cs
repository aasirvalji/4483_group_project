using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public static int numberOfEnemies;
    [SerializeField] private SceneTransition sceneTransition;
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
        numberOfEnemies = GameObject.FindGameObjectWithTag("EnemySpawnerManager").GetComponent<LevelEnemies>().levelEnemyCount + 1; 
        animator = GetComponent<Animator>();
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);

        numberOfEnemies--;
        if (numberOfEnemies == 0)
        {
            Debug.Log("All enemies destroyed!");
            sceneTransition.FadeToLevel(nextScene);
        }
    }
}
