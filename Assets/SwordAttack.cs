using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 2;
    Vector2 rightAttackOffset;
    public Collider2D swordCollider;

    private void Start()
    {
        rightAttackOffset = transform.position;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            BossEnemy boss = other.GetComponent<BossEnemy>();
            if (enemy)
            {
                enemy.Health -= damage;
               
            }
            if (boss)
            {
                boss.Health -= damage;
               
            }
        }
    }
}
