using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private bool isFacingRight = true;
    private Vector2 velocity;
    public float deathAnimationDelay = 1.5f;

    PlayerMovement playerMovement;
    PlayerDeath playerDeath;
    Animator animator;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerDeath = GetComponent<PlayerDeath>();
        animator = GetComponent<Animator>();
        

    }

    void Update()
    {
        velocity = playerMovement.PlayerVelocity;
        if (velocity.x < 0 && isFacingRight || velocity.x > 0 && !isFacingRight)
        {
            ChangeHorizontalDirection();
        }
        animator.SetBool("isJumping", !playerMovement.IsGrounded);

    }

    private void FixedUpdate()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(velocity.x));
        animator.SetFloat("yVelocity", velocity.y);
    }

    public void ChangeHorizontalDirection()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }



}