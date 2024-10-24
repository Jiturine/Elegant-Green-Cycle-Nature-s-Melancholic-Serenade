using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NodeCanvas.DialogueTrees;
using UnityEngine;
using UnityEngine.UI;

public class EpilogueSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM("Epilogue");
        dialogueTree.StartDialogue((endDialogue) =>
        {
            epilogue.end = false;
            changingBackground = true;
        });
        transparent = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        panelColor = new Color(1.0f, 1.0f, 1.0f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (changingBackground)
        {
            background.color = Vector4.MoveTowards(background.color, transparent, Time.deltaTime);
            panel.color = Vector4.MoveTowards(panel.color, panelColor, Time.deltaTime);
            if (background.color.a == 0)
            {
                changingBackground = false;
            }
        }
    }
    private Color transparent;
    private Color panelColor;
    public DialogueTreeController dialogueTree;
    public Epilogue epilogue;
    public bool changingBackground;
    public Image background;
    public Image panel;
}
