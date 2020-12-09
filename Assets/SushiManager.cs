using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiManager : MonoBehaviour
{

    public Transform playerTransform;

    public GameObject sushi;

    public float minDistance = 2f;

    private bool canEatSushi = false;

    private bool isSushiEaten = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canEatSushi && Input.GetKey(KeyCode.E) && (playerTransform.position - transform.position).magnitude <= minDistance && !isSushiEaten) 
        {
            sushi.SetActive(false);
            isSushiEaten = true;
        }
    }

    public void CanEatSushi(bool canEatSushi)
    {
        this.canEatSushi = canEatSushi;
    }

    public bool IsSushiEaten()
    {
        return isSushiEaten;
    }

}
