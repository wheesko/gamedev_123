using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaTriggerController : MonoBehaviour
{
    public GameObject ArenaTrapDoor;

    [SerializeField]
    private GameObject Arena;

    private bool arenaTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !arenaTriggered)
        {
            ArenaTrapDoor.SetActive(true);
            arenaTriggered = true;

            foreach(Transform child in Arena.transform)
            { 
                if(child.gameObject.CompareTag("Enemy"))
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}
