using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuSceneManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayBGM("Prologue");
    }
    public void OnStartGameBtnClick()
    {
        DisableButtons();
        SceneManager.LoadScene("Prologue");
    }
    public void OnGroupListBtnClick()
    {
        DisableButtons();
        SceneManager.LoadScene("Group List");
    }
    public void OnQuitGameButtonClick()
    {
        DisableButtons();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void DisableButtons()
    {
        startGameButton.enabled = false;
        groupListButton.enabled = false;
        quitGameButton.enabled = false;
    }
    public Button startGameButton;
    public Button groupListButton;
    public Button quitGameButton;
}
