using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int damage = 10;
    public string collisionTag;
    private Health health;
    [SerializeField] private Animator animator;
    private float direction;
    public float Direction
    {
        get { return direction; }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        health = col.gameObject.GetComponent<Health>();
        if (health != null)
        {
            direction = (col.transform.position - transform.position).x;
            animator.SetFloat("Direction", Mathf.Abs(direction));
        }
    }

    public void SetDamage()
    {
        if (health != null)
            health.TakeHit(damage);
        health = null;
        direction = 0;
        animator.SetFloat("Direction", 0f);
    }
}
