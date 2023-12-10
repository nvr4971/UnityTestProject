using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DriveMode
{
    Automatic,
    Manual
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float destinationOffset;

    [SerializeField] private Transform currentDestination;
    [SerializeField] private int currentDestinationIndex;

    [SerializeField] private Transform checkpointsListObject;
    [SerializeField] private List<Transform> checkpoints;

    [SerializeField] private DriveMode driveMode;

    private void Start()
    {
        for (int i = 0; i < checkpointsListObject.childCount; i++)
        {
            checkpoints.Add(checkpointsListObject.GetChild(i));
        }

        currentDestinationIndex = 0;
        currentDestination = checkpoints[currentDestinationIndex];
    }

    private void Update()
    {
        if (driveMode == DriveMode.Automatic)
        {
            AutomaticDrive();
        }
        else
        {
            ManualDrive();
        }
        
    }

    private void ManualDrive()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 movement = new(xAxis, 0, zAxis);

        transform.Translate(speed * Time.deltaTime * movement);
    }

    private void AutomaticDrive()
    {
        if (Vector3.SqrMagnitude(currentDestination.position - transform.position) < destinationOffset)
        {
            currentDestination = GetNextCheckpoint();
        }
        else
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        transform.SetPositionAndRotation(
            Vector3.MoveTowards(transform.position, currentDestination.position, Time.deltaTime * speed), 
            Quaternion.LookRotation(currentDestination.position - transform.position)
        );
    }

    private Transform GetNextCheckpoint()
    {
        currentDestinationIndex++;

        if (currentDestinationIndex > checkpoints.Count)
        {
            currentDestinationIndex = 0;
        }

        return checkpoints[currentDestinationIndex];
    }
}
