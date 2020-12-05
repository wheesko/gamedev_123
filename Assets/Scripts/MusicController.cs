using UnityEngine;
public class MusicController : MonoBehaviour
{
    public static MusicController Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public enum MusicType {
        Ambient,
        Fight,
        LevelEnd
    };

    private AudioSource audioSource;
    public AudioClip FightTheme; 
    public AudioClip AmbientTheme;

    public bool IsPlayingMusic;

    public MusicType CurrentMusicType;

    void Start()
    {
        IsPlayingMusic = true;
        CurrentMusicType = MusicType.Ambient;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = AmbientTheme;
        Play(MusicType.Ambient);
    }

    public void Play(MusicType musicType)
    {
        IsPlayingMusic = true;
        audioSource.Stop();
        switch(musicType)
        {
            case MusicType.Ambient:
                audioSource.PlayOneShot(AmbientTheme, 0.20f);
                break;
            case MusicType.Fight:            
                audioSource.PlayOneShot(FightTheme, 0.10f);
                break;
            case MusicType.LevelEnd:
                Stop(); //TODO: Maybe find a level end song 
                break;
        }
    }

    public void Stop()
    {
        IsPlayingMusic = false;
        audioSource.Stop();
    }
}
