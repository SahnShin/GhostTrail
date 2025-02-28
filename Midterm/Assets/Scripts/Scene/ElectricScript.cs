using UnityEngine;
using System.Collections;

public class ElectricScript : MonoBehaviour
{
    private LoopAnimation loopAnimation;
    private SpriteRenderer spriteRenderer;
    public Sprite defaultSprite;

    void Start()
    {
        loopAnimation = GetComponent<LoopAnimation>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (gameObject.name == "Electric1") 
            {
                ElectricManager.Instance.playerOnSwitch1 = true;
                Debug.Log("Player stepped on switch 1");
                StartCoroutine(loopAnimation.SingleAnimationLoop());
            }
            else if (gameObject.name == "Electric2")
            {
                ElectricManager.Instance.playerOnSwitch2 = true;
                Debug.Log("Player stepped on switch 2");
                StartCoroutine(loopAnimation.SingleAnimationLoop());
            }
        }
        else if (collider.CompareTag("Enemy"))
        {
            if (gameObject.name == "Electric1") 
            {
                ElectricManager.Instance.enemyOnSwitch1 = true;
                Debug.Log("Enemy stepped on switch 1");
                StartCoroutine(loopAnimation.SingleAnimationLoop());
            }
            else if (gameObject.name == "Electric2")
            {
                ElectricManager.Instance.enemyOnSwitch2 = true;
                Debug.Log("Enemy stepped on switch 2");
                StartCoroutine(loopAnimation.SingleAnimationLoop());
            }
        }

        ElectricManager.Instance.CheckGateCondition(); // Recheck when someone steps on
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (gameObject.name == "Electric1")
            {
                ElectricManager.Instance.playerOnSwitch1 = false;
                Debug.Log("Player left switch 1");
                StopAllCoroutines();
                StartCoroutine(ResetSpriteAfterFrame());
            } 
            else if (gameObject.name == "Electric2") 
            {
                ElectricManager.Instance.playerOnSwitch2 = false;
                Debug.Log("Player left switch 2");
                StopAllCoroutines();
                StartCoroutine(ResetSpriteAfterFrame());
            }
        }
        else if (collider.CompareTag("Enemy"))
        {
            if (gameObject.name == "Electric1")
            {
                ElectricManager.Instance.enemyOnSwitch1 = false;
                Debug.Log("Enemy left switch 1");
                StopAllCoroutines();
                StartCoroutine(ResetSpriteAfterFrame());
            }
            else if (gameObject.name == "Electric2")
            {
                ElectricManager.Instance.enemyOnSwitch2 = false;
                Debug.Log("Enemy left switch 2");
                StopAllCoroutines();
                StartCoroutine(ResetSpriteAfterFrame());
            }
        }

        ElectricManager.Instance.CheckGateCondition();
    }

    IEnumerator ResetSpriteAfterFrame()
    {
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.sprite = defaultSprite;
    }

}
