using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    
    public TextAsset jsonFile;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lineText;

    private Dialogue Dial;

    private int line = -1;

    private void OnEnable()
    {
        GameManager.Instance.Interacting = true;
        SetDialogue(jsonFile);
    }

    public void SetDialogue(TextAsset dialogue)
    {
        jsonFile = dialogue;
        Dial = JsonUtility.FromJson<Dialogue>(jsonFile.text);
        line = -1;
        NextLine();
    }

    private void OnDisable()
    {
        GameManager.Instance.Interacting = false;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            NextLine();
        }
    }

    private void NextLine()
    {
        line++;
        if(line>=Dial.lines.Count)
        {
            gameObject.SetActive(false);
            return;
        }

        nameText.text = Dial.lines[line].name;
        lineText.text = Dial.lines[line].line;
    }
}

[Serializable]
public class DialogueLine
{
    public string name;
    public string line;
}

[Serializable]
public class Dialogue
{
    public List<DialogueLine> lines;
}

