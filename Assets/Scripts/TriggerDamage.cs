using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool isDestroyingAfterCollision;
    [SerializeField] private GameObject playerInventory;
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
        if (GameManager.Instance.coinContainer.ContainsKey(col.gameObject))
        {
            var coin = GameManager.Instance.coinContainer[col.gameObject];
            var inventory = playerInventory.GetComponent<PlayerInventory>();
            Debug.Log(coin.CoinCount);
            inventory.AddCoin(coin.CoinCount);
            coin.StartDestroy();
        }
        if (GameManager.Instance.healthContainer.ContainsKey(col.gameObject)) 
        {
            var health = GameManager.Instance.healthContainer[col.gameObject];
            health.TakeHit(damage);
            var animator = col.gameObject.GetComponent<Animator>();
            animator.SetTrigger("GetDamage"); 
        }
        if(isDestroyingAfterCollision)
            Destroy(gameObject);
    }
}
