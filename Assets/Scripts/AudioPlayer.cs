using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays audio clips by unique name. Audio clips must be added to the audioClips array in the inspector.
/// </summary>
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    private Dictionary<string, AudioClip> audioClipsDict;

    void Awake()
    {
        audioClipsDict = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClip in audioClips)
        {
            if (!audioClipsDict.ContainsKey(audioClip.name))
            {
                audioClipsDict.Add(audioClip.name, audioClip);
            }
            else
            {
                Debug.LogError("Duplicate audio clip name: " + audioClip.name);
            }
        }
    }

    /// <summary>
    /// Plays the audio clip with the given name. The name is the name of the audio clip file without the extension.
    /// </summary>
    /// <param name="audioClipName">The name of the audio clip file without the extension.</param>
    public void PlayAudioClip(string audioClipName, bool music = false)
    {
        if (audioSource == null)
        {
            Debug.LogError("Audio source not set");
            return;
        }
        if (!audioClipsDict.ContainsKey(audioClipName))
        {
            Debug.LogError("Audio clip not found: " + audioClipName);
            return;
        }
        if (music && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.loop = music;
        audioSource.clip = audioClipsDict[audioClipName];
        audioSource.Play();
    }
}
