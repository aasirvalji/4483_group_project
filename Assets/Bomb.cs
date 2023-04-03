using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" & gameObject.tag == "PLayer")
        {
            animator.SetBool("Exploded", true);
        }
         if (collision.gameObject.tag == "Player" & gameObject.tag == "Enemy")
        {
            animator.SetBool("Exploded", true);
        }
    }

    void BlowUp()
    {
        Destroy(gameObject);
    }
}
