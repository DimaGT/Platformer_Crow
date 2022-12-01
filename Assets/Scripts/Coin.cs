using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinCount = 1; 
    public int CoinCount
    {
        get { return coinCount; }
        set { coinCount = value; }
    }
}
