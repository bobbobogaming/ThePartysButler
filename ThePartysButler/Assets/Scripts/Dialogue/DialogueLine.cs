using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    [TextArea] public string dialogue;
    public KeyValuePairObject<string,string>[] DialogueOptions;
}
