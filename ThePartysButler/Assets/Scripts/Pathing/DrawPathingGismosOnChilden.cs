using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPathingGismosOnChilden : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        transform.parent.GetComponent<DrawPathingGizmo>().DrawLines();
        transform.parent.GetComponent<DrawPathingGizmo>().DrawPathPoints();
    }
}
