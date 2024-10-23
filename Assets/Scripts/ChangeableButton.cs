using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeableButton : MonoBehaviour
{
    void Awake()
    {
        button = transform.Find("Button").GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        KeycodeName = transform.Find("Button").GetComponentInChildren<Text>();
        behaviourName = transform.Find("Behaviour Name").GetComponent<Text>().text;
    }
    void Start()
    {
    }
    void OnButtonClick()
    {
        var button = ChangeButtonManager.Instance.curButton;
        if (button != null)
        {
            button.KeycodeName.text = button.keyCode.ToString();
        }
        ChangeButtonManager.Instance.curButton = this;
        KeycodeName.text = "请输入按键";
    }
    public Button button;
    public Text KeycodeName;
    public KeyCode keyCode;
    public KeyCode defaultKeyCode;
    public string behaviourName;
}
