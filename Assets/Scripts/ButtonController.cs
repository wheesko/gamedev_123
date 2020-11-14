using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Material EnabledMaterial;
    public Material DisabledMaterial;
    private bool objectEnabled = false;
    public GameObject Button;
    public GameObject ControlledObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has triggered the button");
            if (objectEnabled)
            {
                Button.GetComponent<MeshRenderer>().material = DisabledMaterial;
                objectEnabled = false;
            }
            else
            {
                Button.GetComponent<MeshRenderer>().material = EnabledMaterial;
                objectEnabled = true;
            }

            ControlledObject.SetActive(objectEnabled);
        }
    }
}
