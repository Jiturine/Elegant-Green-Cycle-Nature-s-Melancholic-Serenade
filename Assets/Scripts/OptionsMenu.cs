using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class OptionsMenu : MonoBehaviour
{
    public static OptionsMenu Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Instance.gameObject.SetActive(false);
    }

    void Update()
    {

    }
    public void ToggleMenu()
    {
        Instance.gameObject.SetActive(!Instance.gameObject.activeSelf);
        if (Instance.gameObject.activeSelf)
        {
            Time.timeScale = 0;
            if (Game.Instance != null) Game.Instance.gameState = EGameState.Pause;
        }
        else
        {
            Time.timeScale = 1;
            if (Game.Instance != null) Game.Instance.gameState = EGameState.Play;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
    public void OnMusicVolumeChange(float value)
    {
        AudioManager.Instance.MusicVolume = value;
    }
    public void OnSoundEffectVolumeChange(float value)
    {
        AudioManager.Instance.SoundEffectVolume = value;
    }
    public RectTransform rectTransform;
}