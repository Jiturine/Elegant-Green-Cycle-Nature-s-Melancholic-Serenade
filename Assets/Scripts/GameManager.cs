using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get; set;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        sceneIndex = 0;
        SceneLoader.Instance.LoadScene(sceneIndex);
    }

    void Update()
    {

    }
    public int sceneIndex;
}
