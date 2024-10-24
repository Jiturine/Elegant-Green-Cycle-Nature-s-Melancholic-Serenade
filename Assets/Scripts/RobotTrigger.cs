using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;

public class RobotTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !BossLevelSceneManager.Instance.bossAbleToAttack)
        {
            Game.Instance.gameState = EGameState.Pause;
            BossLevelSceneManager.Instance.dialogueTree2.StartDialogue((endDialogue) =>
            {
                Game.Instance.gameState = EGameState.Play;
                BossLevelSceneManager.Instance.bossAbleToAttack = true;
            });
        }
    }
}
