using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject
{
    public string DialogueExitCode;
    public DialogueLine[] dialogueLines;
}
