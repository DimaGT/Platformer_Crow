using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    private void Start()
    {
        GameManager.Instance.healthContainer.Add(gameObject, this);
    }

    public void TakeHit(int damage)
    {
        health -= damage;
            Debug.Log(health);
        if (health <= 0)
            Destroy(gameObject);
        
    }

    public void SetHealth(int bonusHealth)
    {
        this.health += bonusHealth;
    }
}
