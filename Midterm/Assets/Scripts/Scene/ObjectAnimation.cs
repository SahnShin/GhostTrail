using UnityEngine;
using System.Collections;

public class ObjectAnimation : MonoBehaviour
{
    private BoxCollider2D objectCollider;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public float lifeTime = 1f;
    public float holdTime = 0f;
    public bool isCoroutineRunning = false;
    public Vector2[] colliderOffsets = 
    {
        new Vector2(0f, 0f),
        new Vector2(0f, 0f),
        new Vector2(0f, 0f),
        new Vector2(0f, 0f)
    };
    
    void Start()
    {
        objectCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator MoveDown()
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(holdTime);
        float WaitTime = lifeTime/sprites.Length;
        for (int i = 0; i < sprites.Length; i++)
        {
            spriteRenderer.sprite = sprites[i];
            objectCollider.offset = colliderOffsets[i];

            yield return new WaitForSeconds(WaitTime);
        }
        isCoroutineRunning = false;
    }
        
    public IEnumerator MoveUp()
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(holdTime);
        float WaitTime = lifeTime/sprites.Length;
        for (int i = sprites.Length - 1; i >= 0; i--)
        {
            spriteRenderer.sprite = sprites[i];
            objectCollider.offset = colliderOffsets[i];

            yield return new WaitForSeconds(WaitTime);
        }
        isCoroutineRunning = false;
    }
}

