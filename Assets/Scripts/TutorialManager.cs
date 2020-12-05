using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] popUps;

    private int popUpIndex = 0;

    private float movementTimer = 2f;

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
            if (Input.GetButton("Jump"))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKey(KeyCode.C))
            {
                popUpIndex++;
            }
        }

    }
}
