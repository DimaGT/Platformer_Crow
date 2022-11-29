using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int coinsCount;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Coin"))
        {
            coinsCount++;
            Destroy(col.gameObject);
        }
    }
}
