using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance
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
    void Update()
    {
        loadSceneTimer -= Time.deltaTime;
        if (loadingScene && loadSceneTimer < 0)
        {
            SceneManager.LoadScene(loadSceneName);
            loadingScene = false;
        }
    }
    public void LoadScene(string name)
    {
        animator = GameObject.Find("Mask Image").GetComponent<Animator>();
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
        loadingScene = true;
        loadSceneTimer = 2.0f;
        loadSceneName = name;
    }
    public bool loadingScene;
    private float loadSceneTimer;
    public string loadSceneName;
    public Animator animator;
}
