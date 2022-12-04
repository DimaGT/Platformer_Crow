using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image health;
    [SerializeField] private float delta;
    private float healthValue;
    private float currentHealth;
    private Player player;
    [SerializeField] private Text healthText;

    void Start()
    {        
        player = FindObjectOfType<Player>();
        healthValue = player.Health.CurrentHealth / 100.0f;
        healthText.text = "HP " + player.Health.CurrentHealth.ToString();
    }
    void Update()
    {
        currentHealth = player.Health.CurrentHealth / 100.0f;
        if (currentHealth > healthValue)
        {
            healthValue += delta;
        }
        if (currentHealth < healthValue)
        {
            healthValue -= delta;
        }
        if (currentHealth  < delta)
        {
            healthValue = currentHealth;
        }
        healthText.text = "HP " + player.Health.CurrentHealth.ToString();
        health.fillAmount = healthValue;
    }
}
