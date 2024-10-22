using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuSceneManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayBGM("Prologue");
    }
    public void OnStartGameBtnClick()
    {
        startGameButton.enabled = false;
        StartCoroutine(SceneLoader.Instance.LoadScene(++GameManager.Instance.sceneIndex));
    }
    public Button startGameButton;
}
