using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region  Singleton
    public static GameManager Instance { get; private set; }
    #endregion

    public Dictionary<GameObject, Health> healthContainer;
    public Dictionary<GameObject, Coin> coinContainer;
    public Dictionary<GameObject, BuffReceiver> buffReceiverContainer;


    private void Awake()
    {
        Instance = this;
        healthContainer = new Dictionary<GameObject, Health>();
        coinContainer = new Dictionary<GameObject, Coin>();
        buffReceiverContainer = new Dictionary<GameObject, BuffReceiver>();

    }

    public void OnClickPause()
    {        
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
        SceneManager.LoadScene(0);
    }

}
