using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelSceneManager : MonoBehaviour
{
    public void OnLevel1BtnClick()
    {
        SceneManager.LoadScene("Level 1");
    }
}
