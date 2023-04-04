using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public ContactFilter2D movementFilter;
    SpriteRenderer spriteRenderer;
    public SwordAttack swordAttack;
    [SerializeField]
    private GameObject kunai;
    Vector2 movementInput;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Rigidbody2D rb;
    bool canMove = true;
    public float collisionOffset = 0.045f;
    Animator animator;
    public float movementSpeed = 0.9f;
    [SerializeField]
    private int attackMode = 0;
    private Vector2 dir;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {

                bool success = TryMove(movementInput);

                if (!success) success = TryMove(new Vector2(movementInput.x, 0));

                if (!success) success = TryMove(new Vector2(0, movementInput.y));


                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false  ;
            }
        }
    }
    void OnSelectRanged(){
        attackMode = 1;
    }
    void OnSelectMelee(){
        attackMode = 0;
    }
    void OnSelectBomb(){
        attackMode = 2;
    }

    public void PlayerSwordAttack()
    {
        LockMovement();

        if (spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.AttackRight();
        }
    }

    public void EndSwordAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            dir = direction;
            int count = rb.Cast(
                direction, 
                movementFilter,
                castCollisions,
                movementSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * movementSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }

    void OnFire()
    {
        if(attackMode == 0){
        animator.SetTrigger("swordAttack");
        }
        if(attackMode == 1){
        GameObject ammo = Instantiate(kunai,swordAttack.transform.position, Quaternion.AngleAxis(Vector2.Angle(transform.forward, dir), Vector3.forward));
        Destroy(ammo, 3);
        Rigidbody2D ammoRigidbody = ammo.GetComponent<Rigidbody2D>();
        ammoRigidbody.AddForce(dir * 200f);
        }
        if(attackMode == 2){
        animator.SetTrigger("swordAttack");
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

}
