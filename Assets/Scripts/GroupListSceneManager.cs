using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GroupListSceneManager : MonoBehaviour
{
    public void OnBackToStartMenuBtnClick()
    {
        backButton.enabled = false;
        SceneManager.LoadScene("Start Menu");
    }
    public Button backButton;
}
