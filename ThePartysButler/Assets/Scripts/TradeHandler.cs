using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class TradeHandler : MonoBehaviour
{
    [SerializeField] private DialogueEventDispatcher dialogueEventDispatcher;
    [SerializeField] private InventoryObject inventoryObject;

    void Start()
    {
        dialogueEventDispatcher.EventDispatched +=  HandleDialogueEvent; ;
    }
    private void HandleDialogueEvent(string eventName) {
        var tradeDetails = ParseTradeEvent(eventName);
        if (tradeDetails == null) { return; }
        if (tradeDetails?.amount > 0)
        {
            for (int i = 0; i < tradeDetails?.amount; i++)
            {
                inventoryObject.AddItem(tradeDetails?.item);
            }
            return;
        }

        var item = inventoryObject.items.FirstOrDefault(i => i.item == tradeDetails?.item);
        if (item == null || item.amount < Math.Abs(tradeDetails?.amount ?? 0))
        {
            dialogueEventDispatcher.DispatchEvent("failed_" + eventName);
            return;
        }

        item.amount += tradeDetails?.amount ?? 0;
        dialogueEventDispatcher.DispatchEvent("succed_" + eventName);
    }
    private Trade? ParseTradeEvent(string eventName) {
        if (string.IsNullOrEmpty(eventName)) { return null; }
        if (!eventName.StartsWith("trade_")) { return null; }
        var eventParams = eventName.Split("trade_").Last().Split("_");

        return new Trade() {
            item = eventParams[0],
            amount = int.Parse(eventParams[1])
        };
    }

    private struct Trade {
        public string item;
        public int amount;
    }
}
