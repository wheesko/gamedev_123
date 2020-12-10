using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
    [SerializeField]
    private GameObject arenaExitDoor;

    [SerializeField]
    private List<GameObject> enemies;

    private bool arenaReady = false;

    // Start is called before the first frame update
    void Start()
    {
        GetAllEnemies();
        arenaExitDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (arenaReady)
        {
            ClearEnemyList();
        }

        if (enemies.Count == 0 && arenaReady)
        {
            arenaExitDoor.SetActive(true);
        }
    }

    private void ClearEnemyList()
    {
        // When an object is removed, List contains 'missing gameobject'...
        for (int i = enemies.Count; i-- > 0;)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
    }

    private void GetAllEnemies()
    {
        enemies = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Enemy"))
            {
                enemies.Add(child.gameObject);
                child.gameObject.SetActive(false);
            }
        }

        arenaReady = true;
    }
}
