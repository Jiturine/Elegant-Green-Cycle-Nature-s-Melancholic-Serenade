using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance
    {
        get; set;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Init()
    {
        audioSource = GetComponent<AudioSource>();
        // sceneMusic = new AudioClip[10];
    }
    public void PlayBGM(int index)
    {
        if (audioSource.clip != null) audioSource.Stop();
        audioSource.clip = sceneMusic[index];
        audioSource.Play();
        // switch (index)
        // {
        // }
    }
    public void PlaySound(AudioClip clip)
    {
        GameObject audioObject = new GameObject("SoundEffect");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioObject, clip.length);
    }
    public AudioClip[] sceneMusic;
    public AudioSource audioSource;
}
