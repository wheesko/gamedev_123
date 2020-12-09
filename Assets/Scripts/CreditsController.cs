using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{

    public float scrollSpeed = 65f;

    public float scrolledDistance = 0f;

    public float creditsLength = 1800f;

    public GameObject credits;
 
    void Update()
    {
        float deltaDistance = scrollSpeed * Time.deltaTime;
        scrolledDistance += deltaDistance;

        credits.transform.Translate(Vector3.up * deltaDistance);

        if (scrolledDistance > creditsLength)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
