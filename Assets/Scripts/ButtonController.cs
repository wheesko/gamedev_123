using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Material EnabledMaterial;
    public Material DisabledMaterial;
    private bool enabled = false;
    public GameObject Button;
    public GameObject ControlledObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has triggered the button");
            if (enabled)
            {
                Button.GetComponent<MeshRenderer>().material = DisabledMaterial;
                enabled = false;
            }
            else
            {
                Button.GetComponent<MeshRenderer>().material = EnabledMaterial;
                enabled = true;
            }

            ControlledObject.SetActive(enabled);
        }
    }
}
