using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TabSelectionHandler : MonoBehaviour
{
    [SerializeField] KeyValuePairObject<string,Button>[] tabButtons;
    [SerializeField] KeyValuePairObject<string,GameObject>[] tabs;
    // Start is called before the first frame update
    void Start()
    {
        tabButtons[0].Value.Select();
        foreach (var  tab in tabButtons)
        {
            tab.Value.onClick.AddListener(() => SelectTab(tab.Key));
        }
    }

    private void SelectTab(string tabName)
    {
        foreach(var tab in tabs) { tab.Value.SetActive(false); }
        tabs.FirstOrDefault(p=>p.Key == tabName)?.Value.SetActive(true);
    }
}
