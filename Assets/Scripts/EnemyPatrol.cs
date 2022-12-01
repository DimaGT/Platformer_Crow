using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject leftBorder;
    public GameObject rightBorder;
    public Rigidbody2D rigidbody;
    public GroundDetection groundDetection;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CollisionDamage collisionDamage;
    [SerializeField] private Animator animator;
    [SerializeField] private bool staying;

    public bool isRightDirection;

    public float speed;

    private void Update()
    {
        if (transform.position.x > rightBorder.transform.position.x && !staying)
            {
                StartCoroutine(ChangeDirection());
                isRightDirection = false;
            }
        else if (transform.position.x < leftBorder.transform.position.x && !staying)
            {
                StartCoroutine(ChangeDirection());
                isRightDirection = true;
            }
        if(!staying)
        {
            if ( groundDetection.isGrounded)
            {
                if (transform.position.x > rightBorder.transform.position.x || collisionDamage.Direction < 0)
                    {
                        isRightDirection = false;
                    }
                else if (transform.position.x < leftBorder.transform.position.x || collisionDamage.Direction > 0)
                    isRightDirection = true;
                rigidbody.velocity = isRightDirection ? Vector2.right : Vector2.left;
                rigidbody.velocity *= speed;
            }
            else if (groundDetection.isGrounded)
            {
                rigidbody.velocity = Vector2.left * speed;
                if (transform.position.x < leftBorder.transform.position.x)
                    isRightDirection = !isRightDirection;
            }
            if (rigidbody.velocity.x > 0)
                spriteRenderer.flipX = true;
            else if (rigidbody.velocity.x < 0)
                spriteRenderer.flipX = false;
        }
    }

    IEnumerator ChangeDirection()
    {
        staying = true;
        animator.SetBool("isStaying", staying);

        yield return new WaitForSeconds(5); 

        if (transform.position.x > rightBorder.transform.position.x)
            transform.position = new Vector2(!isRightDirection ? rightBorder.transform.position.x : leftBorder.transform.position.x, transform.position.y);
        else if (transform.position.x < leftBorder.transform.position.x)
            transform.position = new Vector2(!isRightDirection ? rightBorder.transform.position.x : leftBorder.transform.position.x, transform.position.y);
        staying = false;
        animator.SetBool("isStaying", staying);
    }
}
