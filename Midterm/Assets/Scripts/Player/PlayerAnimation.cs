using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private bool isFacingRight = true;
    private Vector2 velocity;
    public float deathAnimationDelay = 1.5f;

    PlayerMovement playerMovement;
    PlayerDeath playerDeath;
    Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerDeath = GetComponent<PlayerDeath>();
        animator = GetComponent<Animator>();
        

    }

    // Update is called once per frame
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