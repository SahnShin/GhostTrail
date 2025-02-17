using UnityEngine;
using System.Collections;

public class ScreenScript : MonoBehaviour
{
    private ObjectAnimation gateAnimation;
    public float WaitTime = 1f;
    private bool playerTouching = false;
    public Sprite[] sprites;
    private SpriteRenderer screenRenderer;

    void Start()
    {
        screenRenderer = GetComponent<SpriteRenderer>();
        GameObject Gate = GameObject.Find("Gate");
        gateAnimation = Gate.GetComponent<ObjectAnimation>();
    }

    void Update()
    {
    
    }

    private bool IsPlayerTouching(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayerTouching(collision))
        {
            playerTouching = true;
            Debug.Log("Player is touching obj");
            if (!gateAnimation.isCoroutineRunning)
            {
                StartCoroutine(gateAnimation.MoveDown());
                screenRenderer.sprite = sprites[0];
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerTouching)
        {
            playerTouching = false;
            Debug.Log("Player is no longer touching obj");    
            if (!gateAnimation.isCoroutineRunning)
            {
                Invoke("StartGateCoroutine", WaitTime);
                screenRenderer.sprite = sprites[1];
            }
        }
    }

    void StartGateCoroutine()
    {
        StartCoroutine(gateAnimation.MoveUp());
    }

}
