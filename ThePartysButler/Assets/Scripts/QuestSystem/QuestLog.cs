using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Quest Log")]
public class QuestLog : ScriptableObject
{
    public QuestInstance[] activeQuests;

    public void AddQuest(Quest quest)
    {
        var instance = new QuestInstance()
        {
            quest = quest
        };
        activeQuests = activeQuests.Append(instance).ToArray();
    }
}
