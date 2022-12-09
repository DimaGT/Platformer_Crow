using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image icon;
    private Item item;

    private void Awake()
    {
        icon.sprite = null;
    }
    public void Init(Item item)
    {
        this.item = item;
        icon.sprite = item.Icon;
    }
}
