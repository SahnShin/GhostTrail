using UnityEngine;
using System.Collections;

public class ObjectKill : MonoBehaviour
{

    public CapsuleCollider2D killCollider;
    public Vector2[] killZoneOffset =
    {
        new Vector2(0f, -0.85f),
        new Vector2(0f, -0.85f),
        new Vector2(0f, -.5f),
        new Vector2(0f, 0f),
        new Vector2(0f, 0f)
    };
    public int spriteNumber;
    public float lifeTime = 1f;
    public float holdTime = 0f;
    public bool isCoroutineRunning = false;
    
    void Start()
    {
    }


    void Update()
    {
        
    }

    public IEnumerator MoveDown()
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(holdTime);
        float WaitTime = lifeTime/spriteNumber;
        for (int i = 0; i < spriteNumber; i++)
        {
            killCollider.offset = killZoneOffset[i];
            yield return new WaitForSeconds(WaitTime);
        }
        isCoroutineRunning = false;
    }
        
    public IEnumerator MoveUp()
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(holdTime);
        float WaitTime = lifeTime/spriteNumber;
        for (int i = spriteNumber - 1; i >= 0; i--)
        {
            killCollider.offset = killZoneOffset[i];
            yield return new WaitForSeconds(WaitTime);
        }
        isCoroutineRunning = false;
    }
}
