using UnityEngine;
using System.Collections;

public class LoopAnimation : MonoBehaviour
{
    private ObjectAnimation objectAnimation;
    private ObjectKill objectKill;
    public bool isHammer; 
    public bool isElectric;
    void Start()
    {
        if (isHammer)
        {
            objectKill = GetComponent<ObjectKill>();
        }
        objectAnimation = GetComponent<ObjectAnimation>();

        if (isHammer)
        {
            StartCoroutine(DoubleAnimationLoop());
        }
        else if (!isHammer && !isElectric)
        {
            StartCoroutine(SingleAnimationLoop());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SingleAnimationLoop()
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
