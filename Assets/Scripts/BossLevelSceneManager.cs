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
        firstLoadTimer = 1f;
        firstLand = true;
    }
    void Start()
    {
        AudioManager.Instance.PlayBGM("Robot");
    }
    void Update()
    {
        firstLoadTimer -= Time.deltaTime;
        if (firstLand && firstLoadTimer < 0)
        {
            firstLand = false;
            Game.Instance.gameState = EGameState.Pause;
            dialogueTree1.StartDialogue((endDialogue) =>
                {
                    Game.Instance.gameState = EGameState.Play;
                });
        }
    }
    float firstLoadTimer;
    bool firstLand;
    public DialogueTreeController dialogueTree1;
    public DialogueTreeController dialogueTree2;
    public bool bossAbleToAttack;
}
