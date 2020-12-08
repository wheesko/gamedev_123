using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaTriggerController : MonoBehaviour
{
    public GameObject ArenaTrapDoor;
    private bool arenaTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !arenaTriggered)
        {
            ArenaTrapDoor.SetActive(true);
            arenaTriggered = true;
        }
    }
}
