using UnityEngine;
using System.Collections;

public class ObjectAnimation : MonoBehaviour
{
    private BoxCollider2D objectCollider;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public float lifeTime = 1f;
    public bool isCoroutineRunning = false;
    public Vector2[] colliderOffsets = 
    {
        new Vector2(0f, 0.75f),
        new Vector2(0f, 0.3f),
        new Vector2(0f, 0f),
        new Vector2(0f, 0f)
    };
    
    void Start()
    {
        objectCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        
    }

    public IEnumerator MoveDown()
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(0.5f);
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
        yield return new WaitForSeconds(0.5f);
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
