using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject levelStartSlipgate;

    [SerializeField]
    private GameObject levelEndSlipgate;


    private float levelStartTime;
    public static int SecretCount;
    public static int EnemyCount;
    public static int FoundSecretCount;
    public static int KilledEnemyCount;
    public static float LevelTime;
    public static bool LevelDone;

    // Start is called before the first frame update
    void Start()
    {
        LevelDone = false;
        FoundSecretCount = 0;
        KilledEnemyCount = 0;
        SecretCount = GameObject.FindGameObjectsWithTag("Secret").Length;
        EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        PutPlayerOnTheStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelDone)
        {
            LevelTime += Time.deltaTime;
        }
    }

    private void PutPlayerOnTheStart()
    {
        player.transform.position = levelStartSlipgate.transform.position;
    }
}
