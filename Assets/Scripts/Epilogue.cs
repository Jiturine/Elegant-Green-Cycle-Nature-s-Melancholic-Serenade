using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using ParadoxNotion.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Epilogue : MonoBehaviour
{
    public DialogueTreeController dialogueTree;
    void Awake()
    {
        epilogueText = new List<string> {
            "艾雅看向远方，一片祥和，一切都是如此美好。",
            "“要是这样的美景能一直持续下去就好了。”",
            "脑中的声音回答她：“如果人类能够吸取教训的话，这样的惨剧也许不会再发生。如果真有那么一天……大概自然会选中她新的守护者，和你进行一样的旅程吧。”",
            "艾雅不由得一怔。",
            "现在的惨剧在千百年前也仍旧发生过吗？在从原始到现代的进化历程中人类一直在重蹈覆辙吗？当下全新的世界也会再次迎来秩序的崩塌吗？她的存在只是不断出现的没有任何作用的节点吗？",
            "“请指引我……人类的未来，到底是真正的光明，还是不知悔改的无数次循环呢？”",
            "……",
        };
    }
    void Start()
    {
        end = true;
        fadeIn = true;
        currentTextIndex = 0;
        text.text = epilogueText[currentTextIndex];
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
                text.color = new Color(0.0f, 0.0f, 0.0f, alpha);
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
                text.color = new Color(0.0f, 0.0f, 0.0f, alpha);
            }
            else
            {
                showTimer += Time.deltaTime;
#if UNITY_EDITOR
                if (showTimer > 1f)
#else
                if (showTimer > Mathf.Max(epilogueText[currentTextIndex].Length * 0.05f, 2f))
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
        if (currentTextIndex == epilogueText.Count - 1)
        {
            EndGame();
        }
        else
        {
            text.text = epilogueText[++currentTextIndex];
        }
    }
    private void EndGame()
    {
        var animator = GameObject.Find("Mask Image").GetComponent<Animator>();
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
        end = true;
        finalTextAnimator.SetBool("End", true);
    }
    public Text text;
    public Animator finalTextAnimator;
    private bool fadeIn;
    private bool fadeOut;
    private float showTimer;
    public List<string> epilogueText;
    public int currentTextIndex;
    public bool end;
}