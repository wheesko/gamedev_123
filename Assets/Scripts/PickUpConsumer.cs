using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpConsumer : MonoBehaviour
{
    public GameObject Weapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeWeapon(Weapon);
            Destroy(gameObject);
        }
    }
}
