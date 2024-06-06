using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathing : MonoBehaviour
{
    [SerializeField] private Transform path;
    private Transform[] checkpoints;
    private int currentCheckpointIndex = 0;
    [SerializeField] private float speed;
    [SerializeField] private bool loopPathing;
    // Start is called before the first frame update
    void Start()
    {
        if (path.CompareTag("PathingList"))
        {
            checkpoints = path.GetComponentsInChildren<Transform>();
            currentCheckpointIndex = 1;
            transform.position = checkpoints[currentCheckpointIndex].position;
            Debug.Log(checkpoints[currentCheckpointIndex + 1].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (path == null) { return; }
        if (currentCheckpointIndex+1 > checkpoints.Length-1) { return; }
        if ((checkpoints[currentCheckpointIndex + 1].position - transform.position).sqrMagnitude <= .001f)
        {
            transform.position = checkpoints[currentCheckpointIndex + 1].position;
            currentCheckpointIndex++;
            return;
        }

        if (loopPathing) { currentCheckpointIndex %= checkpoints.Length - 2; }

        transform.position = transform.position + (speed * Time.deltaTime * (checkpoints[currentCheckpointIndex + 1].position - transform.position).normalized);
    }
}
