using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
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
            audioSource = GetComponent<AudioSource>();
            sceneMusic = new Dictionary<string, AudioClip>
            {
                ["Prologue"] = Resources.Load<AudioClip>("AudioClip/Prologue"),
                ["Forest"] = Resources.Load<AudioClip>("AudioClip/Forest")
            };
            soundEffect = new Dictionary<string, AudioClip>
            {
                ["Attack"] = Resources.Load<AudioClip>("AudioClip/Attack")
            };
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {

    }
    public void PlayBGM(string name)
    {
        if (audioSource.clip != null) audioSource.Stop();
        audioSource.clip = sceneMusic[name];
        audioSource.loop = true;
        audioSource.Play();
        Debug.Log(audioSource.clip.name);
    }
    public void PlaySound(string name)
    {
        GameObject audioObject = new GameObject("SoundEffect");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect[name];
        audioSource.volume = SoundEffectVolume;
        audioSource.Play();
        Destroy(audioObject, soundEffect[name].length);
    }
    public void PlayMoveSFX()
    {
        if (!playerMoveSFX.isPlaying)
        {
            playerMoveSFX.UnPause();
        }
    }
    public void StopMoveSFX()
    {
        if (playerMoveSFX.isPlaying)
        {
            playerMoveSFX.Pause();
        }
    }
    public Dictionary<string, AudioClip> sceneMusic;
    public Dictionary<string, AudioClip> soundEffect;
    public AudioSource audioSource;
    private float musicVolume;
    public float MusicVolume
    {
        get => musicVolume;
        set
        {
            musicVolume = value;
            audioSource.volume = value;
        }
    }
    public AudioSource playerMoveSFX;
    public float soundEffectVolume;
    public float SoundEffectVolume { get => soundEffectVolume; set => soundEffectVolume = value; }
}
