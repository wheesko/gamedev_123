using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFightTheme : MonoBehaviour
{
    public GameObject entryPoint;
    private bool musicStarted = false;

    public MusicController musicController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !musicStarted)
        {
            musicStarted = true;
            Debug.Log("Player entered area to play music");
            musicController.GetComponent<MusicController>().Play(MusicController.MusicType.Fight);
        }
    }
}
