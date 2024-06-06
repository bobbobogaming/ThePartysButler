using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class CameraController : MonoBehaviour
{
    public Vector2 movementWindow;
    public float panSpeed;
    public Transform playerTransform;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Abs(transform.position.x - playerTransform.position.x) > movementWindow.x)
        {
            transform.position = transform.position + (new Vector3{x = playerTransform.position.x - transform.position.x} / panSpeed) * Time.deltaTime;
        }
        if (Abs(transform.position.y - playerTransform.position.y) > movementWindow.y)
        {
            transform.position = transform.position + (new Vector3{y = playerTransform.position.y - transform.position.y} / panSpeed) * Time.deltaTime;
        }
    }
}
