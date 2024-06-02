using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestSheduler : MonoBehaviour
{
    [SerializeField] private DialogueEventDispatcher dialogueEventDispatcher;
    [SerializeField] private QuestLog questsLog;
    [SerializeField] private Quest[] quests;
    // Start is called before the first frame update
    void Start()
    {
        dialogueEventDispatcher.EventDispatched += HandleDialogueEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleDialogueEvent(string eventName) 
    {
        var quest = quests.FirstOrDefault(i => i.questId == ParseQuestEvent(eventName));
        if (quest == null) { return; }
        Debug.Log("quest added");
        questsLog.AddQuest(quest);
    }

    private int ParseQuestEvent(string eventName)
    {
        if (string.IsNullOrEmpty(eventName)) {  return -1; }
        if (!eventName.StartsWith("start_quest_")) { return -1; }
        return int.Parse(eventName.Split("start_quest_").Last());
    }
}
