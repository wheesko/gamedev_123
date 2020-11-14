using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
    [SerializeField]
    private GameObject arenaExitDoor;

    [SerializeField]
    private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        arenaExitDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count == 0)
        {
            arenaExitDoor.SetActive(true);
        }   
    }
}
