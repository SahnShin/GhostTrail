using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateMovement(float xVelocity, float yVelocity)
    {
        animator.SetFloat("xVelocity", Mathf.Abs(xVelocity));
        animator.SetFloat("yVelocity", yVelocity);
    }

    public void SetJumping(bool isJumping)
    {
        if (animator.GetBool("isJumping") != isJumping)
        {
            animator.SetBool("isJumping", isJumping);
        }
    }


}
