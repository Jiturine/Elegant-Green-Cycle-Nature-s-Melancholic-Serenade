using System.Collections.Generic;
using ParadoxNotion.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
    void Awake()
    {
        prologueText = new List<string> {
            "在遥远的未来，人类文明的繁荣曾如璀璨星辰般照亮天际，却也在不经意间，以无尽的贪婪和短视，悄然编织了一张生态失衡的网。天空变得死寂般灰暗，河水仅留下枯竭的哀歌，大地再容不下生机的草木，映入眼帘的仅剩下蜷缩痛苦的灰黄。洪水、干旱、飓风与沙尘暴成了这个时代的代名词。生物多样性的宝库逐渐枯竭，物种灭绝的钟声在寂静中回响，提醒着人们曾经的错误与遗憾。在一片黑暗与混沌中，人们绝望着，呐喊着，嘶吼着……但似乎一切都不可弥补。",
            "直到那一天，先民的古老预言被再次提起——存在一种能够与自然沟通的守护者，当他们拥有自然之力，便可不断推进生态循环的演进，那么修复破碎生态，归还地球以绿水青山便指日可待。于是，他们开始到处寻找预言中的守护者，急不可待地想抓住这唯一的希望。充满命运意味的那一天到来了，夜里伴随着一声嘹亮的婴儿哭泣，世界的秩序似乎被引动，希望似乎孕育而生……",
            "你是艾雅，诞生于一片荒芜与混沌的世界中，天生便可以听到一些遥远的呼唤。开始时你不解，恐惧，随着时间推移，慢慢地便习以为常，但令你非常疑惑的是，那个声音仿佛只会重复“孩子，救救我”，你尝试对话，但无人回应。（这里可以弄一个对话的场景，但无人回应）直到某一天，你接触到了那个古老的预言，懵懵懂懂中似乎明白了什么……",
            "这次，你来到人类世代守护的祭坛中虔心祈祷，并尝试再次沟通，令你惊喜的是，那个声音有了回应。",
            "“遥远的声音，我能听到你的呼唤，我是预言中的守护者吗？”",
            "“孩子，是的，你将背负起拯救人类的重任!”",
            "“可是，可是我该怎么做呢？”",
            "“你守护者的身份让你能与自然界的植物沟通，你需要通过与他们的对话获取自然的力量，揭露并阻止那些继续破坏环境、加剧生态危机的幕后黑手，修复地球的自然循环，恢复那曾经和谐共生的生态平衡”",
            "“我有点怕……”",
            "“孩子，我的时间不多了，向西走，便能开始你的旅途，人类只有你能拯救了！”",
            "之后，无论你再怎么努力，却再也没有了回应……",
            "晚上，你躺在床上，看着墙上挂着的以前的画作：绿水青山，珍禽遍地，阳光和煦……你的眼神变得坚毅，下定了决心",
            "第二天，人们便发现艾雅消失的无影无踪，只留下西边的一串脚印，似乎指引着人们该去往何方……"
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
                if (showTimer > Mathf.Min(prologueText[currentTextIndex].Length * 0.1f, 2f))
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
            GameManager.Instance.sceneIndex++;
            StartCoroutine(SceneLoader.Instance.LoadScene(GameManager.Instance.sceneIndex));
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