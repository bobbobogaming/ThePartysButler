using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    public DialogueObject currentDialogue;
    private int iDialogueLine = 0;
    [SerializeField] private IUIState playState;

    [SerializeReference] private DialogueEventDispatcher dialogueEventTrigger;

    void OnEnable()
    {
        iDialogueLine = 0;
        dialogueBox.SetActive(true);
        dialogueText.text = currentDialogue.dialogueLines[iDialogueLine++].dialogue;
    }

    void OnNextLine(InputValue inputValue)
    {
        if (iDialogueLine >= currentDialogue.dialogueLines.Length)
        {
            dialogueBox.SetActive(false);
            GetComponent<UIStateContext>().ChangeState(playState);
            dialogueEventTrigger.DispatchEvent(currentDialogue.DialogueExitCode);
            //enabled = false;
            return;
        }
        dialogueText.text = currentDialogue.dialogueLines[iDialogueLine++].dialogue;
    }
}
