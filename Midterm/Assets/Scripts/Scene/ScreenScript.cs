using UnityEngine;
using System.Collections;

public class ScreenScript : MonoBehaviour
{
    public float WaitTime = 1f;
    public Sprite[] sprites;
    private SpriteRenderer screenRenderer;
    private ObjectAnimation gateAnimation;
    private AudioSource audioSource;

    private bool playerTouching = false;
    private bool isMovingUp = false;
    private bool isMovingDown = false;

    void Start()
    {
        screenRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        GameObject Gate = GameObject.Find("Gate");
        gateAnimation = Gate.GetComponent<ObjectAnimation>();
    }

    private bool IsPlayerTouching(Collider2D collider)
    {
        return collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsPlayerTouching(collider) && !isMovingDown) 
        {
            playerTouching = true;

            if (isMovingUp)
            {
                StopCoroutine(gateAnimation.MoveUp());
                isMovingUp = false;
            }
            StartCoroutine(MoveGateDown());
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (IsPlayerTouching(collider) && playerTouching)
        {
            playerTouching = false;
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
        AudioManager.Instance.PlaySound(audioSource.clip, 0.4f);
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
