using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinCount = 2;
    [SerializeField] private Animator animator;

    private void Start()
    {
        GameManager.Instance.coinContainer.Add(gameObject, this);
    }

    public int CoinCount
    {
        get { return coinCount; }
        set { coinCount = value; }
    }
    public void StartDestroy()
    {
        animator.SetTrigger("StartDestroy");
    }
    public void EndDestroy()
    {
        Destroy(gameObject);
    }

}
