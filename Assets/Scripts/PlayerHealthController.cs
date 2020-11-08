using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int maxHealth;
    public int currentHealth;

    public float invincibleLength = 1f;
    private float invincibleCounter;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        /*UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "Health: " + currentHealth + "/" + maxHealth;*/
    }

    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if (invincibleCounter <= 0)
        {
            //AudioManager.instance.PlaySFX("player_hurt");
            currentHealth -= damageAmount;
           // UIController.instance.ShowDamage();

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
                currentHealth = 0;
                /*GameManager.instance.PlayerDied();
                AudioManager.instance.StopBackgroundMusic();
                AudioManager.instance.StopSFX("player_hurt");
                AudioManager.instance.PlaySFX("player_dead");*/
            }
            invincibleCounter = invincibleLength;
            /*UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = "Health: " + currentHealth + "/" + maxHealth;*/
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        /*UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "Health: " + currentHealth + "/" + maxHealth;*/
    }
}
