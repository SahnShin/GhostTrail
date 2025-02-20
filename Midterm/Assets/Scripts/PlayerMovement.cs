using UnityEngine;
using System.Collections;
using UnityEditor.ShaderGraph;

public class PlayerMovement : MonoBehaviour
{

    float direction;
    public float moveSpeed = 5f;
    bool isFacingRight = false;
    public float jumpForce = 20f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isGrounded;

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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxisRaw("Horizontal");

        ChangeHorizontalDirection();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocityX, jumpForce);

        }

        animator.SetBool("isJumping", !isGrounded);

    }

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = new Vector2(direction * moveSpeed, playerRigidbody.linearVelocityY);
        animator.SetFloat("xVelocity", Mathf.Abs(playerRigidbody.linearVelocityX));
        animator.SetFloat("yVelocity", playerRigidbody.linearVelocityY);
    }

    private void ChangeHorizontalDirection()
    {
        if (!isFacingRight && direction < 0 || isFacingRight && direction > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }




}

