using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupListSceneManager : MonoBehaviour
{
    public void OnBackToStartMenuBtnClick()
    {
        backButton.enabled = false;
        StartCoroutine(SceneLoader.Instance.LoadScene("Start Menu"));
    }
    public Button backButton;
}
