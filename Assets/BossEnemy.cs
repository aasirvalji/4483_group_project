using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    private SlimeSpawner slimeSpawner;
    private SceneTransition sceneTransition;
    Animator animator;
    [SerializeField] 
    private string nextScene;
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
        animator = GetComponent<Animator>();
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");

    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
    private void OnDestroy() {
          if(gameObject.name == "Boss") {
            print(nextScene);
            Time.timeScale = 0f;
            SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);

        } else {
            return;
        }
    }
    public void CleanScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

