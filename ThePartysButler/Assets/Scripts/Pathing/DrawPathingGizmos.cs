using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPathingGizmo : MonoBehaviour
{
    public void DrawLines()
    {
        var children = GetComponentsInChildren<Transform>();

        for (int i = 1; i < children.Length - 1; i++) {
            Gizmos.DrawLine(children[i].position, children[i + 1].position);
        }
    }

    public void DrawPathPoints() 
    {
        var children = GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if (child == transform) { continue; }
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(child.position,0.5f);
        }
    }
}
