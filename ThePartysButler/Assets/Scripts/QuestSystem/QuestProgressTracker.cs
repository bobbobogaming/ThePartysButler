using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestProgressTracker : MonoBehaviour
{
    [SerializeField] private DialogueEventDispatcher dialogueEventDispatcher;
    [SerializeField] private QuestLog questsLog;
    // Start is called before the first frame update
    void Start()
    {
        dialogueEventDispatcher.EventDispatched += HandleDialogueEvent;
    }
    private void HandleDialogueEvent(string eventName) {
        var quest = questsLog.activeQuests.FirstOrDefault(q => q.quest.progressEvenId == eventName);
        if (quest == null) { return; }
        Debug.Log("quest progressed");
        quest.progress++;
        if (quest.progress == quest.quest.requiredCount)
        {
            questsLog.activeQuests = questsLog.activeQuests.Where(q => q.progress != q.quest.requiredCount).ToArray();
        }
    }
}
