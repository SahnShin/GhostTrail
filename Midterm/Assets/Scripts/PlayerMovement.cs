using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    float horizontalInput;
    public float moveSpeed = 5f;
    bool isFacingRight = false;

    public float jumpForce = 20f;
    bool isGrounded = true;

    Rigidbody2D playerRigidbody;
    Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        ChangeHorizontalDirection();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocityX, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = new Vector2(horizontalInput * moveSpeed, playerRigidbody.linearVelocityY);
        animator.SetFloat("xVelocity", Mathf.Abs(playerRigidbody.linearVelocityX));
        animator.SetFloat("yVelocity", playerRigidbody.linearVelocityY);
    }

    private void ChangeHorizontalDirection()
    {
        if (!isFacingRight && horizontalInput < 0 || isFacingRight && horizontalInput > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
}

