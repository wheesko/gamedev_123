using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public enum MusicType {
        AMBIENT,
        FIGHT
    };

    private AudioSource audioSource;
    public AudioClip fightTheme; 
    public AudioClip ambientTheme;

    public bool isPlayingMusic;

    public MusicType currentMusicType;

    void Start()
    {
        isPlayingMusic = true;
        currentMusicType = MusicType.AMBIENT;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ambientTheme;
        Play(MusicType.AMBIENT);
    }

    public void Play(MusicType musicType)
    {
        isPlayingMusic = true;
        audioSource.Stop();
        switch(musicType)
        {
            case MusicType.AMBIENT:
                audioSource.PlayOneShot(ambientTheme, 0.5f);
                break;
            case MusicType.FIGHT:            
                audioSource.PlayOneShot(fightTheme, 0.5f);
                break;
            default:
                break;
        }
    }
}
