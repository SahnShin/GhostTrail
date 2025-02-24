using System.Collections;
using UnityEngine;

public class ShadowAnimation : MonoBehaviour
{
    private Animator animator;
    private ShadowController shadowController;
    private SpriteRenderer spriteRenderer;

    private bool isFacingRight = true;
    private Vector2 velocity;
    private int currentIndex;

    public float fadeDuration = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        shadowController = GetComponent<ShadowController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        currentIndex = shadowController.CurrentPositionIndex;

        if (currentIndex < shadowController.RecordedDirections.Count)
        {
            velocity = shadowController.RecordedDirections[currentIndex];
            if (velocity.x < 0 && isFacingRight || velocity.x > 0 && !isFacingRight)
            {
                ChangeHorizontalDirection();
            }

            animator.SetBool("isJumping", velocity.y > 0);
        } else
        {
            StartCoroutine(FadeOutAndDestroyShadow());
        }

    }

    private void FixedUpdate()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(velocity.x));
        animator.SetFloat("yVelocity", velocity.y);
    }

    private void ChangeHorizontalDirection()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private IEnumerator FadeOutAndDestroyShadow()
    {
        float fadeSpeed = 1f / fadeDuration;
        Color originalColor = spriteRenderer.color;

        for (float time = 0; time < 1; time += Time.deltaTime * fadeSpeed)
        {
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1- time);
            yield return null;
        }

        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        Destroy(gameObject);
    }
    


}
