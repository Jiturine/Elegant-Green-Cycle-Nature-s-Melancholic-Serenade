using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !FirstLevelSceneManager.Instance.hasTriggered)
        {
            FirstLevelSceneManager.Instance.hasTriggered = true;
            Game.Instance.gameState = EGameState.Pause;
            FirstLevelSceneManager.Instance.dialogueTree2.StartDialogue((endDialogue) =>
            {
                Game.Instance.gameState = EGameState.Play;
                FirstLevelSceneManager.Instance.tooltipText.gameObject.SetActive(true);
                FirstLevelSceneManager.Instance.tooltipText.text = $"按{Character.Instance.abilityKey}键使用能力";
            });
        }
    }
}
