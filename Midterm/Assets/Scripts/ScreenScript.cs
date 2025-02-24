using UnityEngine;
using System.Collections;

public class ScreenScript : MonoBehaviour
{
    public float WaitTime = 1f;
    public Sprite[] sprites;
    private SpriteRenderer screenRenderer;
    private ObjectAnimation gateAnimation;

    private bool playerTouching = false;
    private bool isMovingUp = false;
    private bool isMovingDown = false;

    void Start()
    {
        screenRenderer = GetComponent<SpriteRenderer>();
        GameObject Gate = GameObject.Find("Gate");
        gateAnimation = Gate.GetComponent<ObjectAnimation>();
    }

    private bool IsPlayerTouching(Collision2D collision)
    {
        return collision.gameObject.CompareTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayerTouching(collision) && !isMovingDown) 
        {
            playerTouching = true;
            Debug.Log("Player is touching obj");

            if (isMovingUp)
            {
                StopCoroutine(gateAnimation.MoveUp());
                isMovingUp = false;
            }

            StartCoroutine(MoveGateDown());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsPlayerTouching(collision) && playerTouching)
        {
            playerTouching = false;
            Debug.Log("Player is no longer touching obj");
            screenRenderer.sprite = sprites[1];

            if (!isMovingUp && !isMovingDown) 
            {
                Invoke("StartMoveGateUp", WaitTime);
            }
        }
    }

    void StartMoveGateUp()
    {
        if (!isMovingUp && !playerTouching) 
        {
            StartCoroutine(MoveGateUp());
        }
    }

    IEnumerator MoveGateDown()
    {
        isMovingDown = true;
        screenRenderer.sprite = sprites[0];
        yield return StartCoroutine(gateAnimation.MoveDown());
        isMovingDown = false;
    }

    IEnumerator MoveGateUp()
    {
        isMovingUp = true;
        yield return StartCoroutine(gateAnimation.MoveUp());
        isMovingUp = false;
    }
}
