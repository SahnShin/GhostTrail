using UnityEngine;
using System.Collections;

public class LoopAnimation : MonoBehaviour
{
    private ObjectAnimation objectAnimation;
    void Start()
    {
        objectAnimation = GetComponent<ObjectAnimation>();
        StartCoroutine(AnimationLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AnimationLoop()
    {
        while (true)
        {
            yield return StartCoroutine(objectAnimation.MoveDown());
        }
    }
}
