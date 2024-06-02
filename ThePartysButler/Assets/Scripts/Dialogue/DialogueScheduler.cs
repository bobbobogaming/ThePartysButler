using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueScheduler : MonoBehaviour
{
    [SerializeField] private DialogueEventDispatcher dialogueEventDispatcher;
    [SerializeField] private KeyValuePairObject<string,DialogueObject>[] dialogueObjects;

    // Start is called before the first frame update
    void Start()
    {
        dialogueEventDispatcher.EventDispatched += HandleDialogueEvent;

    }
    private void HandleDialogueEvent(string eventName)
    {
        var dialogue = dialogueObjects.FirstOrDefault(i => i.Key == eventName);
        if (dialogue == null) { return; }
        Debug.Log("dispathing Dialoge");
        gameObject.GetComponent<DialogueManager>().PushToDialogueStack(dialogue.Value);
    }
}
