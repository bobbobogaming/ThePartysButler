using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayStateUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject UIObj;
    [SerializeField] private TMP_Text toolBarPlaceholderText;
    [SerializeField] private InventoryObject inventory;

    void OnEnable()
    {
        UIObj.SetActive(true);
        Time.timeScale = 1.0f;
    }
    void OnDisable()
    {
        UIObj.SetActive(false);
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var invStr = "";
        foreach (var item in inventory.items)
        {
            invStr += $"<sprite name=\"{item.item}\">({item.amount})\t";
        }
        toolBarPlaceholderText.text = invStr;
    }
}
