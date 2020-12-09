using UnityEngine;

public class DoorContoller : MonoBehaviour
{
    public GameObject Door;
    [SerializeField]
    private bool doorOpened;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !doorOpened)
        {
            Debug.Log("Player has triggered the door");
            doorOpened = true;
            Door.transform.position += new Vector3(0f, -3.9f, 0f);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && doorOpened)
        {
            Debug.Log("Player has triggered the door close");
            Door.transform.position += new Vector3(0f, 3.9f, 0f);
            doorOpened = false;

            // Door.transform.position = Vector3.Lerp(Door.transform.position, Door.transform.position + new Vector3(0f, -40f, 0f), Time.deltaTime * 1f);
        }
    }
}
