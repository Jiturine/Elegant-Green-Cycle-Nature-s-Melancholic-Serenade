using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Myd.Platform;

public class KeyToolTip : MonoBehaviour
{
    void Update()
    {
        text.text = $"攻击:{Character.Instance.attackKey}\n攀爬:{GameInput.Grab.key}\n跳跃:{GameInput.Jump.key}";
    }
    public TextMeshPro text;
}
