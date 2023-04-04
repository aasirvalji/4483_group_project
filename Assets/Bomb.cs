using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Animator animator;
    Collider2D  col;
    public float damage = 3;
    public float explosionTime = 3;
    private bool exploded = false;
    private bool damageDealt = false;
    void Awake()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        Invoke("Explode", explosionTime);
    }
    private void  OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy" && exploded && !damageDealt)
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy)
            {
                enemy.Health -= damage;
                damageDealt = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        // Reset damageDealt when the player exits the trigger
        if (other.tag ==  "Enemy")
        {
            damageDealt = false;
        }
    }

    void Explode()
    {
        animator.SetTrigger("Explode");
        exploded = true;
    }
    void Destroy(){
        Destroy(gameObject);
    }
}
