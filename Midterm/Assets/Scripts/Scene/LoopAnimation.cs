using UnityEngine;
using System.Collections;

public class LoopAnimation : MonoBehaviour
{
    private ObjectAnimation objectAnimation;
    private ObjectKill objectKill;
    public bool isHammer; 
    void Start()
    {
        if (isHammer)
        {
            objectKill = GetComponent<ObjectKill>();
        }
        objectAnimation = GetComponent<ObjectAnimation>();

        if (!isHammer)
        {
            StartCoroutine(SingleAnimationLoop());
        }
        else
        {
            StartCoroutine(DoubleAnimationLoop());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SingleAnimationLoop()
    {
        while (true)
        {
            yield return StartCoroutine(objectAnimation.MoveDown());
        }
    }

    IEnumerator DoubleAnimationLoop()
    {
        while (true)
        {
            yield return StartCoroutine(objectAnimation.MoveDown());
            StartCoroutine(objectKill.MoveDown());
            yield return StartCoroutine(objectAnimation.MoveUp());
            StartCoroutine(objectKill.MoveUp());
        }
    }
}
