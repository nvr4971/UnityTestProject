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
    [SerializeField] private float acceleration;
    [SerializeField] private float destinationOffset;

    [SerializeField] private Transform currentDestination;
    [SerializeField] private int currentDestinationIndex;

    [SerializeField] private Transform checkpointsListObject;
    [SerializeField] private List<Transform> checkpoints;

    [SerializeField] private DriveMode driveMode;

    private Rigidbody _rb;
    private Vector3 _movementDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _movementDirection = Vector3.zero;

        driveMode = DriveMode.Manual;

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

    private void FixedUpdate()
    {
        _rb.AddForce(acceleration * speed * _movementDirection);

        UIManager.Instance.UpdateSpeedUI(_rb.velocity.magnitude);
    }

    private void ManualDrive()
    {
        _movementDirection = new Vector3(
            Input.GetAxis("Horizontal"), 
            0, 
            Input.GetAxis("Vertical")
        ).normalized;

        transform.rotation = Quaternion.LookRotation(_movementDirection);
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
