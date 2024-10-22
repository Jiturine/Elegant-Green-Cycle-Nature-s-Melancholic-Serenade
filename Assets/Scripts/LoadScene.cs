using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadRespond()
    {
        SceneManager.LoadScene("Respond");
    }

    public void LoadPrefaceContinue()
    {
        SceneManager.LoadScene("PrefaceContinue");
    }

    public void LoadSceneLevel1()
    {
        SceneManager.LoadScene("SceneLevel1");
    }
}
