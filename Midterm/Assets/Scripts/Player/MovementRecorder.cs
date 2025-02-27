using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementRecorder : MonoBehaviour
{
    public List<Vector3> recordedPositions = new List<Vector3>();
    public List<Vector2> recordedDirections = new List<Vector2>();
    public List<bool> recordedJumps = new List<bool>();
    private Vector3 lastPosition;

    public float recordInterval = 0.5f;

    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        lastPosition = transform.position;
        StartCoroutine(RecordMovement());
    }

    void Update()
    {
        
    }

    private IEnumerator RecordMovement()
    {
        while (true)
        {
            Vector3 currentPosition = transform.position;
            Vector2 direction = (currentPosition - lastPosition).normalized;

            recordedDirections.Add(direction);
            recordedPositions.Add(transform.position);
            recordedJumps.Add(!playerMovement.IsGrounded);

            lastPosition = currentPosition;

            yield return new WaitForSeconds(recordInterval);
        }
    }

    public void ResetRecordedPositions()
    {
        recordedDirections.Clear();
        recordedPositions.Clear();
        recordedJumps.Clear();
    }
}
