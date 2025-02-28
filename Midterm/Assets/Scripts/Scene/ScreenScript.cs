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
    private bool isOpening = false;
    private bool isClosing = false;

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
        if (IsPlayerTouching(collider) && !isOpening) 
        {
            playerTouching = true;

            if (isClosing)
            {
                StopCoroutine(gateAnimation.MoveUp());
                isClosing = false;
            }
            StartCoroutine(OpenGate());
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (IsPlayerTouching(collider) && playerTouching)
        {
            playerTouching = false;
            screenRenderer.sprite = sprites[1];

            if (!isOpening && !isClosing) 
            {
                Invoke("StartCloseGate", WaitTime);
            }
        }
    }

    void StartCloseGate()
    {
        if (!isClosing && !playerTouching) 
        {
            StartCoroutine(CloseGate());
        }
    }

    IEnumerator OpenGate()
    {
        isOpening = true;
        screenRenderer.sprite = sprites[0];
        AudioManager.Instance.PlaySound(audioSource.clip, 0.4f);
        yield return StartCoroutine(gateAnimation.MoveDown());
        isOpening = false;
    }

    IEnumerator CloseGate()
    {
        isClosing = true;
        yield return StartCoroutine(gateAnimation.MoveUp());
        isClosing = false;
    }
}
