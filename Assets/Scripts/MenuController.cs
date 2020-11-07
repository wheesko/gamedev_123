using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public static string firstSceneName = "Level1";

    public static void Continue()
    {
        // TODO: add progress tracking
        throw new NotImplementedException();
    }

    public static void NewGame()
    {
        SceneManager.LoadScene(firstSceneName);
    }

    public static void Options()
    {
        // TODO: add Options panel
        throw new NotImplementedException();
    }

    public static void Exit()
    {
        Application.Quit();
    }
}
