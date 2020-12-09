using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledDoorScript : MonoBehaviour
{
    public GameObject Door;

    [SerializeField]
    private bool needsToOpen = false;

    void Start()
    {
        needsToOpen = true;
    }

    private void Update()
    {
        if (needsToOpen)
        {
            Door.transform.position -= new Vector3(0f, 3.9f, 0f);
            needsToOpen = false;
        }
    }   
}
