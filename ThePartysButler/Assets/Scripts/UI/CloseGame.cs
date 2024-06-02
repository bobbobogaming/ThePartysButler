using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseGame : MonoBehaviour
{
    [SerializeField] Button Button;
    // Start is called before the first frame update
    void Start()
    {
        Button.onClick.AddListener(() => Application.Quit());
    }
}
