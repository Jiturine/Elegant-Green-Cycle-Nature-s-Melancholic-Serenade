using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using NodeCanvas.DialogueTrees;
using UnityEngine;

public class BossLevelSceneManager : MonoBehaviour
{
    static public BossLevelSceneManager Instance { get; set; }
    void Awake()
    {
        Instance = this;
        bossAbleToAttack = false;
    }
    void Start()
    {
        AudioManager.Instance.PlayBGM("Robot");
        Game.Instance.gameState = EGameState.Pause;
        dialogueTree1.StartDialogue((endDialogue) =>
            {
                Game.Instance.gameState = EGameState.Play;
            });
    }
    public DialogueTreeController dialogueTree1;
    public DialogueTreeController dialogueTree2;
    public bool bossAbleToAttack;
}
