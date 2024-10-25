using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using ParadoxNotion.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
    public DialogueTreeController dialogueTree;
    void Awake()
    {
        prologueText = new List<string> {
            "在遥远的未来，人类文明的繁荣曾如璀璨星辰般照亮天际，却也在不经意间，以无尽的贪婪和短视，悄然编织了一张生态失衡的网。",
            "天空不再湛蓝，取而代之的是灰蒙蒙的雾霾；大地失去了往日的绿意，干涸的河流与枯萎的森林诉说着无尽的哀歌。极端天气频繁肆虐，洪水、干旱、飓风与沙尘暴，成了这个时代的代名词。",
            "生物多样性的宝库逐渐枯竭，物种灭绝的钟声在寂静中回响，提醒着人们曾经的错误与遗憾。",
            "在一片黑暗与混沌中，在无尽的绝望于悔恨中，人们绝望着，呐喊着，嘶吼着……",
            "但是，一切似乎都已无法弥补……",
            "在人们的惶惶终日中，先民的古老预言被再次提起——存在一种能够与自然沟通的守护者，如果他们拥有了自然之力，那么修复破碎生态，归还地球以绿水清山便指日可待。",
            "于是，绝望中的人们仿佛是久在地底中难见天日突然发现了一缕光芒，他们开始到处寻找预言中的守护者，然而，不知是不是上天对人类的惩罚，人们迟迟没有找到……人们再次陷入了绝望……",
            "但是，人们不知道的是，夜里伴随着一声嘹亮的婴儿哭泣，世界的秩序似乎被引动，希望似乎孕育而生……",
            "你是艾雅，诞生于一片荒芜与混沌的世界中，天生便可以听到一些遥远的呼唤。开始时你不解，恐惧，随着时间推移，慢慢地便习以为常，但令你非常疑惑的是，那个声音仿佛只会重复“孩子，救救我”，你尝试对话，但无人回应。",
            "直到某一天，你接触到了那个古老的预言，懵懵懂懂中似乎明白了什么……",
            "这次，你来到人类世代守护的祭坛中虔心祈祷，并尝试再次沟通，令你惊喜的是，那个声音有了回应。",
            //pause
            "之后，无论你再怎么努力，却再也没有了回应……",
            "晚上，你躺在床上，看着墙上挂着的以前的照片：绿水青山，珍禽遍地，阳光和煦……你的眼神变得坚毅，下定了决心。",
            "第二天，人们便发现艾雅的失踪，只看到西边的一串脚印……"
        };
    }
    void Start()
    {
        fadeIn = true;
        currentTextIndex = 0;
        text.text = prologueText[currentTextIndex];
    }
    void Update()
    {
        if (!end)
        {
            if (fadeIn)
            {
                float alpha = text.color.a + 2f * Time.deltaTime;
                if (alpha > 1.0f)
                {
                    fadeIn = false;
                    alpha = 1.0f;
                }
                text.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            }
            else if (fadeOut)
            {
                float alpha = text.color.a - 2f * Time.deltaTime;
                if (alpha < 0.0f)
                {
                    alpha = 0.0f;
                    fadeOut = false;
                    fadeIn = true;
                    ChangeText();
                }
                text.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            }
            else
            {
                showTimer += Time.deltaTime;
#if UNITY_EDITOR
                if (showTimer > 0f)
#else
                if (showTimer > Mathf.Max(prologueText[currentTextIndex].Length * 0.05f, 2f))
#endif
                {
                    showTimer = 0.0f;
                    fadeOut = true;
                }
            }
        }
    }
    private void ChangeText()
    {
        if (currentTextIndex == prologueText.Count - 1)
        {
            SceneManager.LoadScene("First Level");
            end = true;
        }
        else if (currentTextIndex == 10)
        {
            dialogueTree.StartDialogue((endDialogue) => { end = false; text.text = prologueText[++currentTextIndex]; });
            end = true;
        }
        else
        {
            text.text = prologueText[++currentTextIndex];
        }
    }
    public Text text;
    private bool fadeIn;
    private bool fadeOut;
    private float showTimer;
    public List<string> prologueText;
    public int currentTextIndex;
    public bool end;
}