using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    public int bonusHealth;
    private Health health;
    [SerializeField] private Animator animator;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Enemy"))
        {
            health = col.gameObject.GetComponent<Health>();
            animator.SetTrigger("Healthing");
        }
    }
    public void getHealth()
    {
        health.SetHealth(bonusHealth);
        Destroy(gameObject);
    }
}
