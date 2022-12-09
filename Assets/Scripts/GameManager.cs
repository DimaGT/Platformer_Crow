using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region  Singleton
    public static GameManager Instance { get; private set; }
    #endregion
    [SerializeField] private GameObject inventoryPanel;
    public Dictionary<GameObject, Health> healthContainer;
    public Dictionary<GameObject, Coin> coinContainer;
    public Dictionary<GameObject, BuffReceiver> buffReceiverContainer;
    public Dictionary<GameObject, ItemComponent> itemsContainer;
    [HideInInspector] public PlayerInventory inventory;
    public ItemBase itemDataBase;


    private void Awake()
    {
        Instance = this;
        healthContainer = new Dictionary<GameObject, Health>();
        coinContainer = new Dictionary<GameObject, Coin>();
        buffReceiverContainer = new Dictionary<GameObject, BuffReceiver>();
        itemsContainer = new Dictionary<GameObject, ItemComponent>();
    }

    public void OnClickPause()
    {        
        
        if (Time.timeScale > 0) 
        {
            inventoryPanel.gameObject.SetActive(true);
            Time.timeScale =  0;
        }
        else
        {
            Time.timeScale =  1;
            inventoryPanel.gameObject.SetActive(false);
        }

    }

}
