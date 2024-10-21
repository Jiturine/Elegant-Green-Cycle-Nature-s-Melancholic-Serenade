using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelSceneManager : MonoBehaviour
{
    public void OnLevel1BtnClick()
    {
        StartCoroutine(SceneLoader.Instance.LoadScene("Level 1"));
    }
}
