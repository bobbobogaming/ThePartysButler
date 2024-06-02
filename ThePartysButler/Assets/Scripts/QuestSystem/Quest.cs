using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Quest")]
public class Quest : ScriptableObject
{
    [SerializeField] public int questId;
    [SerializeField] public string discription;
    [SerializeField] public int requiredCount;
    [SerializeField] public string progressEvenId;
}
