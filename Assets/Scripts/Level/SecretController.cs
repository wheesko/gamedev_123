using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You've found a secret!");
        }
    }
}
