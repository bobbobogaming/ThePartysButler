using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    public DialogueObject currentDialogue;
    private int iDialogueLine = 0;
    [SerializeField] private PlayerInput playerPlayerInput;

    void OnEnable()
    {
        playerPlayerInput.enabled = false;
        iDialogueLine = 0;
        dialogueBox.SetActive(true);
        dialogueText.text = currentDialogue.dialogueLines[iDialogueLine++].dialogue;
    }

    void OnNextLine(InputValue inputValue)
    {
        if (iDialogueLine >= currentDialogue.dialogueLines.Length)
        {
            dialogueBox.SetActive(false);
            playerPlayerInput.enabled = true;
            enabled = false;
            return;
        }
        dialogueText.text = currentDialogue.dialogueLines[iDialogueLine++].dialogue;
    }
}
