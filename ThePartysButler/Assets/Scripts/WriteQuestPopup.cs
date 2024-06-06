using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteQuestPopup : MonoBehaviour
{
    [SerializeField] private DialogueEventDispatcher dialogueEventDispatcher;
    private TMP_Text dialogueText;
    private float alfaValue;

    // Start is called before the first frame update
    void Start()
    {
        dialogueEventDispatcher.EventDispatched += HandleDialogueEvent;
        dialogueText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alfaValue > 0f) {
            alfaValue -= Time.deltaTime/1;
            dialogueText.alpha = alfaValue;
        }
    }

    private void HandleDialogueEvent(string eventName)
    {
        if (eventName.StartsWith("start_quest"))
        {
            dialogueText.text = "Quest Started";
            alfaValue = 1f;
        }
        if (eventName.StartsWith("quest_completed"))
        {
            dialogueText.text = "Quest completed";
            alfaValue = 1f;
        }
    }
}
