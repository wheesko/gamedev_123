using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public static GameUIController Instance { get; private set; }

    public Text HealthText;
    public Text AmmoText;

    public Text TimeText;
    public Text EnemiesText;
    public Text SecretsText;

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
        HealthText.text = $"{health}/100";
    }

    public void SetAmmo(int ammo)
    {
        AmmoText.text = ammo.ToString();
    }

    public void EndGame(bool isSuccess)
    {
        TimeText.text = $"{Mathf.Round(LevelManager.LevelTime)} seconds";
        EnemiesText.text = $"{LevelManager.KilledEnemyCount}";
        SecretsText.text = $"{LevelManager.FoundSecretCount}";

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

    public void MainMenu()
    {
        GameController.Instance.MainMenu();
    }

    public void NextLevel()
    {
        GameController.Instance.ProceedToNextLevel();
    }
}
