using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueObject[] dialogueObjects;
    [SerializeField] private DialogueDisplayer dialogueWindow;
    [SerializeField] private IUIState dialogueState;
    [SerializeField] private UIStateContext uiStateContext;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Selector"))
        {
            return;
        }

        dialogueWindow.currentDialogue = dialogueObjects[0];
        uiStateContext.ChangeState(dialogueState);
        //dialogueWindow.enabled = true;
        other.enabled = false;
    }
}
