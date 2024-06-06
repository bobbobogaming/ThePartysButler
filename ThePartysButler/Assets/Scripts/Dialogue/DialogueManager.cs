using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueObject[] idleDialogueObjects;
    public DialogueObject[] dialogueObjectsStack;
    [SerializeField] private DialogueDisplayer dialogueWindow;
    [SerializeField] private IUIState dialogueState;
    [SerializeField] private UIStateContext uiStateContext;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Selector"))
        {
            return;
        }

        //Debug.Log("dialogue queue lenth" + dialogueObjectsStack.Length);
        var lastInCollection = dialogueObjectsStack.LastOrDefault();
        //Debug.Log(lastInCollection);
        if (lastInCollection != null) {
            dialogueWindow.currentDialogue = lastInCollection;
            dialogueObjectsStack = dialogueObjectsStack.SkipLast(1).ToArray();
        }
        else
        {
            dialogueWindow.currentDialogue = idleDialogueObjects[Mathf.Max(0,Mathf.RoundToInt(Random.value * (idleDialogueObjects.Length - 1)))];
        }
        uiStateContext.ChangeState(dialogueState);
        //dialogueWindow.enabled = true;
        other.enabled = false;
    }
    public void PushToDialogueStack(DialogueObject dialogueObject)
    {
        dialogueObjectsStack = dialogueObjectsStack.Append(dialogueObject).ToArray();
    }
}
