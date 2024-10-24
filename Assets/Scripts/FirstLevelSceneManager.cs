using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;

public class FirstLevelSceneManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayBGM("Forest");
    }
    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireCube(Game.Instance.level.StartPosition, Vector2.one);
    // }
}
