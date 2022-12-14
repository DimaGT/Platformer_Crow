using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float force;
    public float minimalHeight = -15;
    public Rigidbody2D rigidbody;
    public bool isCheatMode;
    public GroundDetection groundDetection;
    private Vector3 direction;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public bool isJumping;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform arrowSpawnPoint;
    [SerializeField] private Health health;
    [SerializeField] private bool ladder;
    public Health Health => health;
    private bool allowShoot = true;
    private bool canAddSprint = true;
    private bool addSprint = false;
    


    void Update() 
    {
        if (animator != null)
            animator.SetBool("isGrounded", groundDetection.isGrounded);
        if(!isJumping && !groundDetection.isGrounded && !ladder)
            if (animator != null)
                animator.SetTrigger("StartFall");
        isJumping = isJumping && !groundDetection.isGrounded;
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
            direction = Vector3.left;
        if (Input.GetKey(KeyCode.D))
            direction = Vector3.right; 
        if (Input.GetKey(KeyCode.LeftShift))
            if (canAddSprint)
                StartCoroutine(CooldownSprint());
        if (Input.GetKey(KeyCode.W))
            ladder = true;
        else if (Input.GetKey(KeyCode.S))
            ladder = true;
        else
            ladder = false;

        direction *= speed;
        direction.y = rigidbody.velocity.y;
        rigidbody.velocity = direction;
        if(addSprint)
        {
            rigidbody.velocity = (spriteRenderer.flipX ? Vector3.left : Vector3.right) * speed * 4;
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundDetection.isGrounded)
        {
            rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                if (animator != null)
                    animator.SetTrigger("StartJump");
            isJumping = true;
        }
        if(direction.x > 0)
            spriteRenderer.flipX = false;
        if(direction.x < 0)
            spriteRenderer.flipX = true;
        animator.SetFloat("Speed", Mathf.Abs(direction.x));
        CheckFall();
        CheckShoot();
    }

    void CheckShoot()
    {
        if (Input.GetMouseButtonDown(0) && allowShoot)
        {
            allowShoot = false;
            animator.SetTrigger("Shoot");
        }
    }

    void PrepareShoot()
    {
        prefab = Instantiate(arrow, arrowSpawnPoint.transform.position, Quaternion.identity);
        prefab.GetComponent<Arrow>().SetImpulse(Vector2.right, 0 , gameObject);
    }

    void Shoot()
    {
        prefab.GetComponent<Arrow>().SetImpulse(Vector2.right, spriteRenderer.flipX ? -force * 5  : force * 5 , gameObject);
        StartCoroutine(Cooldown());
    }

    void CheckFall()
    {
        if(transform.position.y < minimalHeight && isCheatMode)
        {
            rigidbody.velocity = new Vector2(0, 10);
            transform.position = new Vector3(0, 0);
        }
        else if (transform.position.y < minimalHeight && !isCheatMode)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1);  
        allowShoot = true;
    }
    private IEnumerator CooldownSprint()
    {
        canAddSprint = false;
        addSprint = true;
        yield return new WaitForSeconds(0.25F);
        addSprint = false;
        yield return new WaitForSeconds(5);
        canAddSprint = true;


        yield break;
    }
}
