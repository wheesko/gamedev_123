using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public static string firstSceneName = "TutorialLevel";

    public static void NewGame()
    {
        SceneManager.LoadScene(firstSceneName);
    }

    public static void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public static void Exit()
    {
        Application.Quit();
    }
}
