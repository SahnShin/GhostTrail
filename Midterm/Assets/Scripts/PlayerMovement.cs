using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    float horizontalInput;
    public float moveSpeed = 5f;
    bool isFacingRight = false;

    public float jumpForce = 20f;
    bool isJumping = false;

    Rigidbody2D playerRigidbody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        ChangeHorizontalDirection();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isJumping)
        {
            playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocityX, jumpForce);
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = new Vector2(horizontalInput * moveSpeed, playerRigidbody.linearVelocityY);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}

