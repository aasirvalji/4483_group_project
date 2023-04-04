using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class BossEnemy : MonoBehaviour
{
    private SlimeSpawner slimeSpawner;
    private SceneTransition sceneTransition;
    string startPath = "Assets/startTime.txt";
    string victoryPath = "Assets/score.txt";
    private
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
        int endTime = (int) (DateTime.Now.TimeOfDay.TotalMilliseconds);
        int startTime = 0;
            using (StreamReader reader = new StreamReader(startPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int.TryParse(line, out startTime);
                }
            }
            using (StreamWriter writer = new StreamWriter(victoryPath))
                {
                    writer.WriteLine(1000000+(startTime-endTime));
                }

            
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

