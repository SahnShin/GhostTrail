using UnityEngine;
using System.Collections;

public class HammerScript : MonoBehaviour
{
    private ObjectAnimation objectAnimation;
    void Start()
    {
        objectAnimation = GetComponent<ObjectAnimation>();
        StartCoroutine(HammerLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator HammerLoop()
    {
        while (true)
        {
            yield return StartCoroutine(objectAnimation.MoveDown());
            yield return StartCoroutine(objectAnimation.MoveUp());
        }
    }
}
