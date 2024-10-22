using NodeCanvas.DialogueTrees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    public GameObject MapManager;
    public DialogueTreeController dialogueTree;
    public void Turnoff()
    {   
        dialogueTree = GameObject.Find("DialogueTree1").GetComponent<DialogueTreeController>();
        MapManager.SetActive(false);
        dialogueTree.StartDialogue();
    }
}
