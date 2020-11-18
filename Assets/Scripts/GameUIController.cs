using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public static GameUIController Instance { get; private set; }

    public Text healthText;
    public Text ammoText;

    public Text timeText;
    public Text enemiesText;
    public Text secretsText;

    public GameObject GameOverPanel;
    public GameObject ScorePanel;
    public GameObject LevelCompletePanel;

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
    }

    // TODO add a proper health bar
    public void SetHealthText(int health)
    {
        health = Mathf.Clamp(health, 0, 100);
        healthText.text = $"{health}/100";
    }

    public void SetAmmo(int ammo)
    {
        ammoText.text = ammo.ToString();
    }

    public void EndGame(bool isSuccess)
    {
        timeText.text = $"{Mathf.Round(LevelManager.LevelTime)} seconds";
        enemiesText.text = $"{LevelManager.KilledEnemyCount}";
        secretsText.text = $"{LevelManager.FoundSecretCount}";

        ScorePanel.SetActive(true);

        if (isSuccess)
        {
            LevelCompletePanel.SetActive(true);
        }
        else
        {
            GameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        GameController.Instance.Restart();
    }
}
