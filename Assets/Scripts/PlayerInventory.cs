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
            var coinValue = col.gameObject.GetComponent<Coin>();
            Debug.Log(coinValue.CoinCount);
            Destroy(col.gameObject);
        }
    }
    public void AddCoin(int count)
    {
        coinsCount += count;
    }
}
