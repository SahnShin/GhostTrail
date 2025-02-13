using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour
{
    public Sprite[] sprites;
    public float lifeTime = 1f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(OpenGate());
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            StartCoroutine(CloseGate());
        }
    }

    public IEnumerator OpenGate()
    {
        yield return new WaitForSeconds(0.5f);
        float WaitTime = lifeTime/sprites.Length;
        for (int i = 0; i < sprites.Length; i++)
        {
            spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(WaitTime);
        }
    }
    public IEnumerator CloseGate()
    {
        yield return new WaitForSeconds(0.5f);
        float WaitTime = lifeTime/sprites.Length;
        for (int i = sprites.Length - 1; i >= 0; i--)
        {
            spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(WaitTime);
        }
    }
}
