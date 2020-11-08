using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorContoller : MonoBehaviour
{
    public GameObject Door;
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
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player has triggered the door");
            Door.transform.position += new Vector3(0f, -3.9f, 0f);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has triggered the door close");
            Door.transform.position += new Vector3(0f, 3.9f, 0f);
            // Door.transform.position = Vector3.Lerp(Door.transform.position, Door.transform.position + new Vector3(0f, -40f, 0f), Time.deltaTime * 1f);
        }
    }
}
