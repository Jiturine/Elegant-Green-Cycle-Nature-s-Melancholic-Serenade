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
            Game.Instance.gameState = EGameState.Pause;
        }
        else
        {
            Time.timeScale = 1;
            Game.Instance.gameState = EGameState.Play;
        }
    }
}