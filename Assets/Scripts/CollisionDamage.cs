using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int damage = 10;
    public string collisionTag;
    private Health health;
    [SerializeField] private Animator animator;

    private void OnCollisionEnter2D(Collision2D col)
    {
        health = col.gameObject.GetComponent<Health>();
        if (health != null)
            animator.SetTrigger("CollisionDamage");
            SetDamage();
    }

    public void SetDamage()
    {
        if (health != null)
            health.TakeHit(damage);
        health = null;
    }
}
