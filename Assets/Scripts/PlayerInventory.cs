using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int coinsCount = 0;
    public Text coinsText;
    private List<Item> items;
    public List<Item> Items
    {
        get { return items; }
    }
    public void Start() {
        GameManager.Instance.inventory = this;
        coinsText.text = coinsCount.ToString();
        items = new List<Item>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (GameManager.Instance.coinContainer.ContainsKey(col.gameObject))
        {
            var coin = GameManager.Instance.coinContainer[col.gameObject];
            AddCoin(coin.CoinCount);
            coin.StartDestroy();
        }
        if (GameManager.Instance.itemsContainer.ContainsKey(col.gameObject))
        {
            var itemComponent = GameManager.Instance.itemsContainer[col.gameObject];
            items.Add(itemComponent.Item);
            itemComponent.Destroy(col.gameObject);
        }

    }
    public void AddCoin(int count)
    {
        coinsCount += count;
        Debug.Log(coinsCount);
        if(coinsText != null)
            coinsText.text = coinsCount.ToString();
    }
}
