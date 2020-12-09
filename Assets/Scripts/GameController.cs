using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController Instance { get; private set; }

    public bool IsPaused { get; private set; }

    public bool IsGameOver { get; private set; }

    // Maps the level with the upcoming one
    private Dictionary<string, string> nextLevelsDictionary = new Dictionary<string, string>()
    {
        { "TutorialLevel", "DemoLevel" }
    };

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

    public void Pause(bool shouldPause)
    {
        IsPaused = shouldPause;
        if (shouldPause)
        {
            Time.timeScale = 0.0f;
            // TODO bring up Pause menu
        }
        else
        {
            Time.timeScale = 1.0f;
            // TODO shut down Pause menu
        }
    }

    public void EndGame(bool isSuccess)
    {
        bool isFinalLevel = !nextLevelsDictionary.ContainsKey(SceneManager.GetActiveScene().name);
        if (!IsGameOver)
        {
            GameUIController.Instance.EndGame(isSuccess, isFinalLevel);
        }
        IsGameOver = true;
    }

    // It's probably not the best approach ¯\_(ツ)_/¯
    public void ProceedToNextLevel()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        if (nextLevelsDictionary.ContainsKey(currentLevel))
        {
            SceneManager.LoadScene(nextLevelsDictionary[currentLevel]);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
