using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public static GameUIController Instance { get; private set; }

    public Text healthText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    // TODO add a proper health bar
    public void SetHealthText(int health)
    {
        health = Mathf.Clamp(health, 0, 100);
        healthText.text = $"{health}/100";
    }
}
