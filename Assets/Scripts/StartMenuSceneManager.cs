using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuSceneManager : MonoBehaviour
{
    public void OnStartGameBtnClick()
    {
        StartCoroutine(SceneLoader.Instance.LoadScene("Select Level"));
    }
}
