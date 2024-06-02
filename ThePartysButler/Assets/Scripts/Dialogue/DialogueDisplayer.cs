using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    public DialogueObject currentDialogue;
    private int iDialogueLine = 0;
    [SerializeField] private IUIState playState;

    [SerializeField] private GameObject dialogueOptionContainer;
    [SerializeField] private Button buttonPrefab;

    [SerializeReference] private DialogueEventDispatcher dialogueEventTrigger;

    void OnEnable()
    {
        iDialogueLine = 0;
        dialogueBox.SetActive(true);
        //AddDialogueOptions(currentDialogue.dialogueLines[iDialogueLine].DialogueOptions);
        //dialogueText.text = currentDialogue.dialogueLines[iDialogueLine++].dialogue;
        AdvanceDialogue();
        EventSystem.current.SetSelectedGameObject(GetComponentInChildren<Button>().gameObject);
    }

    void OnNextLine(InputValue inputValue)
    {
        if (currentDialogue == null) { return; }
        if (dialogueOptionContainer.transform.childCount != 0) { return; }
        AdvanceDialogue();
    }
    private void AdvanceDialogue()
    {
        if (iDialogueLine >= currentDialogue.dialogueLines.Length) {
            dialogueBox.SetActive(false);
            GetComponent<UIStateContext>().ChangeState(playState);
            dialogueEventTrigger.DispatchEvent(currentDialogue.DialogueExitCode);
            currentDialogue = null;
            //enabled = false;
            return;
        }
        AddDialogueOptions(currentDialogue.dialogueLines[iDialogueLine].DialogueOptions);
        dialogueText.text = currentDialogue.dialogueLines[iDialogueLine++].dialogue;
    }
    private void AddDialogueOptions(KeyValuePairObject<string, string>[] options)
    {
        foreach (var item in options) {
            var temp = Instantiate<Button>(buttonPrefab);
            temp.transform.SetParent(dialogueOptionContainer.transform, false);
            temp.GetComponent<RectTransform>().anchoredPosition += (Vector2.up * 30) * (dialogueOptionContainer.transform.childCount - 1);
            temp.GetComponentInChildren<TMP_Text>(true).text = item.Value;
            temp.onClick.AddListener(() => {
                ClearObjChildren(dialogueOptionContainer.transform);
                AdvanceDialogue();
                dialogueEventTrigger.DispatchEvent(item.Key);
            });
        }
    }
    private void ClearObjChildren(Transform obj)
    {
        for (var i = 0; i < obj.childCount; i++)
        {
            Destroy(obj.GetChild(i).gameObject);
        }
    }
}
