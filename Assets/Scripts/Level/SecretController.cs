using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretController : MonoBehaviour
{
    private bool alreadyFound = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !alreadyFound)
        {
            alreadyFound = true;
            Debug.Log("You've found a secret!");
            LevelManager.FoundSecretCount++;
        }
    }
}
