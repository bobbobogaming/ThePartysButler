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
    }
    void OnDisable()
    {
        UIObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var invStr = "";
        foreach (var item in inventory.items)
        {
            invStr = invStr.Equals("") ? "" : invStr + "; ";
            invStr += item.item + $" ({item.amount})";
        }
        toolBarPlaceholderText.text = invStr;
    }
}
