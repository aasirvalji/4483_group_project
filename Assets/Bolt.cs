using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
[SerializeField]
    float damage = 0.5f;
  private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            // Enemy enemy = other.GetComponent<Enemy>();

            // if (enemy)
            // {
            //     enemy.Health -= damage;
               
            // }
            Destroy(gameObject);

        }
    }
}
