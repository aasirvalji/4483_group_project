using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player; // To store the player's Transform component


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Calculate the direction vector from the enemy to the player
        Vector2 direction = (Vector2)player.position - (Vector2)transform.position;
        direction.Normalize();

        // Move the enemy towards the player
        transform.position += (Vector3)direction * randSpeed() * Time.deltaTime;
    }

    float randSpeed()
    {
        return Random.Range(0.01f, 0.25f);
    }
}
