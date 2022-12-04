using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int coinsCount = 0;
    [SerializeField] private Text coinsText;

    private void Start() {
        coinsText.text = coinsCount.ToString();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (GameManager.Instance.coinContainer.ContainsKey(col.gameObject))
        {
            var coin = GameManager.Instance.coinContainer[col.gameObject];
            AddCoin(coin.CoinCount);
            coin.StartDestroy();
        }
    }
    public void AddCoin(int count)
    {
        coinsCount += count;
        coinsText.text = coinsCount.ToString();;
    }
}
