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
        { "Level1", "Level2" }
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
        DontDestroyOnLoad(gameObject);
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

    public void EndGame()
    {
        IsGameOver = true;
        // TODO execute anything related to gameover
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

}
