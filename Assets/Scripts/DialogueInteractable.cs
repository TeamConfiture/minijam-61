using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    public DialogueManager chat;
    public TextAsset dialogue;

    private void Awake()
    {
        chat.gameObject.SetActive(false);
        TextMeshPro tmp = GetComponentInChildren<TextMeshPro>();

        if(tmp != null)
        {
            tmp.text = string.Format(InteractionText, InteractionCommand);
        }

        MakeInteractable(false);
    }

    public override void Interact()
    {
        chat.gameObject.SetActive(true);
        chat.SetDialogue(dialogue);
    }
}
