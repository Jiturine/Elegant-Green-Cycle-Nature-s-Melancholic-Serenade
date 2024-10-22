using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;   

public class Start : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Preface");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GroupList()
    {
        SceneManager.LoadScene("GroupList");
    }
    public void Return()
    {
        SceneManager.LoadScene("BeginMenu");
    }
}
