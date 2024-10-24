using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;

public class ChangeButtonManager : MonoBehaviour
{
    static public ChangeButtonManager Instance { get; set; }
    void Awake()
    {
        Instance = this;
        curButton = null;
    }
    void OnGUI()
    {
        if (curButton != null && Input.anyKeyDown)
        {
            Event e = Event.current;
            // 有事件、事件是按键、按键不是None
            if (e != null && e.isKey && e.keyCode != KeyCode.None && curButton != null)
            {
                KeyCode currentKey = e.keyCode;
                curButton.keyCode = currentKey;
                curButton.KeycodeName.text = currentKey.ToString();
                switch (curButton.behaviourName)
                {
                    case "跳跃":
                        GameInput.Jump.key = currentKey;
                        break;
                    case "攀爬":
                        GameInput.Grab.key = currentKey;
                        break;
                    case "攻击":
                        if (Character.Instance != null)
                        {
                            Character.Instance.attackKey = currentKey;
                            attackKey = currentKey;
                        }
                        break;
                    case "能力":
                        if (Character.Instance != null)
                        {
                            Character.Instance.abilityKey = currentKey;
                            abilityKey = currentKey;
                        }
                        break;
                }
                curButton = null;
            }
        }
    }
    public ChangeableButton curButton;
    static public KeyCode attackKey = KeyCode.J;
    static public KeyCode abilityKey = KeyCode.L;
}
