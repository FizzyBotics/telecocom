using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance = null;
    public AudioPlayer audioPlayer;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate music player self-destructing!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        audioPlayer = GetComponent<AudioPlayer>();
    }

    private void Start()
    {
        audioPlayer.PlayAudioClip("menu", true);
    }
}
