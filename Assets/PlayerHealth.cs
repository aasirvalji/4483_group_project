using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public long damageStart = 0;
    private SceneTransition sceneTransition;

    private void Start()
    {
        GameObject transitionManager = GameObject.Find("SceneTransitionManager");
        sceneTransition = transitionManager.GetComponent<SceneTransition>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, 100);
        Debug.Log("Player health: " + health);

        // Handle player death if health reaches 0
        if (health <= 0)
        {
            // Destroy(gameObject); // Uncomment this line if you want to destroy the player when health reaches 0
            //Debug.Log("Player is dead!");
            sceneTransition.FadeToLevel("DeathScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            print("Collided with enemy");
            long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (damageStart == 0)
            {
                damageStart = currentTime;
            } else
            {
                long diff = currentTime - damageStart;
                if (diff <= 1500) TakeDamage(1);
                damageStart = 0;
            }
        }
    }
    }