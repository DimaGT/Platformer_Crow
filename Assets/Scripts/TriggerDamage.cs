using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool isDestroyingAfterCollision;
    private GameObject parent;
    public GameObject Parent
    {
        get { return parent; }
        set { parent = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == parent)
            return; 
        var health = col.gameObject.GetComponent<Health>();
        if (health != null) 
        {
            health.TakeHit(damage);
        }
        if(isDestroyingAfterCollision)
            Destroy(gameObject);
    }
}
