using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogHandler : MonoBehaviour
{
    [SerializeField] private QuestLog questLog;
    [SerializeField] private Button questPrefab;
    // Start is called before the first frame update
    void OnEnable()
    {
        foreach (var item in questLog.activeQuests)
        {
            var temp = Instantiate<Button>(questPrefab);
            temp.transform.SetParent(transform,false);
            temp.GetComponent<RectTransform>().anchoredPosition += (Vector2.down * 30) * (transform.childCount - 1);
            temp.GetComponentInChildren<TMP_Text>(true).text = item.quest.discription;
        }
    }

    private void OnDisable() {
        foreach (Transform child in transform) 
        {
            Destroy(child.gameObject);
        }
    }
}
