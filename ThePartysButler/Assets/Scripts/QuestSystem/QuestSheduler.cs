using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestSheduler : MonoBehaviour
{
    [SerializeField] private DialogueEventDispatcher dialogueEventDispatcher;
    [SerializeField] private QuestLog questsLog;
    [SerializeField] private KeyValuePairObject<string,Quest>[] quests;
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
        Debug.Log("quest added");
        foreach (var i in quests) {
            Debug.Log(i.Key + ", " + eventName);
            Debug.Log(i.Key == eventName);
            Debug.Log(quests.FirstOrDefault(i => i.Key == eventName).Value.discription);
        }
        questsLog.AddQuest(quests.FirstOrDefault(i => i.Key == eventName).Value);
    }
}
