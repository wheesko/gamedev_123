using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public static TutorialManager Instance { get; private set; }

    public GameObject[] popUps;

    public GameObject toriGateTrigger;

    private int popUpIndex = 0;

    private float movementTimer = 2f;

    private int shotscounter = 2;

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

    void Update()
    {

        for (int i = 0; i < popUps.Length; i++)
        {
            popUps[i].SetActive(popUpIndex == i ? true : false);
        }

        if (popUpIndex == 0)
        {
            if (movementTimer <= 0)
            {
                popUpIndex++;
            }
            else if (Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("Horizontal") != 0f)
            {
                movementTimer -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKey(KeyCode.C))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetButton("Jump"))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (shotscounter <= 0)
            {
                popUpIndex++;
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                shotscounter--;
            }
        }
        else if (popUpIndex == 4)
        {
            toriGateTrigger.SetActive(true);
        }
    }

    public void EndTutorial()
    {
        GameController.Instance.ProceedToNextLevel();
    }

}
