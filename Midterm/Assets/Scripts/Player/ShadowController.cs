using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ShadowController : MonoBehaviour
{
    public float replaySpeed = 6.0f;
    public float delayStart = 3f;

    private List<Vector3> _recordedPositions;
    private List<Vector2> _recordedDirections;
    private int _currentPositionIndex = 0;

    public int CurrentPositionIndex => _currentPositionIndex;
    public List<Vector2> RecordedDirections => _recordedDirections;
    Collider2D shadowCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_recordedPositions == null || _currentPositionIndex >= _recordedPositions.Count)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _recordedPositions[_currentPositionIndex], replaySpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _recordedPositions[_currentPositionIndex]) < 0.001f)
        {
            _currentPositionIndex++;
        }
    }

    public void StartReplay(List<Vector3> recordedPositions, List<Vector2> recordedDirections)
    {
        _recordedPositions = new List<Vector3>(recordedPositions);
        _recordedDirections = new List<Vector2>(recordedDirections);

        if (_recordedPositions.Count > 0)
        {
            transform.position = _recordedPositions[0] + new Vector3(-3f, 0, 0);
        }

        shadowCollider = GetComponent<Collider2D>();
        //if (shadowCollider != null)
        //{
        //    shadowCollider.enabled = false;
        //}

        StartCoroutine(DelayStart());
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(delayStart);

        //if (shadowCollider != null)
        //{
        //    shadowCollider.enabled = true;
        //}
    }
}
