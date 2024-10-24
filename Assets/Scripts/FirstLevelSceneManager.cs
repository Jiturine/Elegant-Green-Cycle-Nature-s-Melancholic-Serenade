using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using NodeCanvas.DialogueTrees;
using TMPro;
using UnityEngine;

public class FirstLevelSceneManager : MonoBehaviour
{
    static public FirstLevelSceneManager Instance { get; set; }
    void Awake()
    {
        Instance = this;
        tooltipText.gameObject.SetActive(false);
    }
    void Start()
    {
        AudioManager.Instance.PlayBGM("Forest");
        dialogueTree1.StartDialogue();
    }
    public DialogueTreeController dialogueTree1;
    public DialogueTreeController dialogueTree2;
    public bool hasTriggered;
    public TextMeshPro tooltipText;
}
