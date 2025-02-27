using UnityEngine;
using System;

public class ProximityDetector : MonoBehaviour
{

    private bool _isPlayerNearby = false;
    public bool IsPlayerNearby => _isPlayerNearby;
    public float boxAngle = 0f;
    public Vector2 boxSize = new Vector2(6f, 1f);
    private Vector2 boxCenter;

    void Start()
    {
        boxCenter = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        Collider2D hit = Physics2D.OverlapBox(boxCenter, boxSize, boxAngle);
        if (hit != null && hit.tag == "Player")
        {
            _isPlayerNearby = true;
        }
        else
        {
            _isPlayerNearby = false;
        }
    }
}
