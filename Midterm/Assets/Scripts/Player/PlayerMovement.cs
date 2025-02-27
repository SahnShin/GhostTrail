using UnityEngine;
using System.Collections;
using UnityEditor.ShaderGraph;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    //player movement variables
    float horizontalInput;
    public float moveSpeed = 5f;
    Vector2 playerVelocity;
    public float jumpForce = 20f;
    private bool jumpButtonPressed;

    //ground check variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool _isGrounded;

    //wall check variables
    private bool _isTouchingWall;
    public Transform wallCheck;
    public float wallCheckRadius;
    private bool _isWallJumping;

    //accessor
    public bool IsGrounded => _isGrounded;
    public Vector2 PlayerVelocity => playerVelocity;

    Rigidbody2D playerRigidbody;
    CatAudio catAudio;

    void Start()
    {

        playerRigidbody = GetComponent<Rigidbody2D>();
        catAudio = GetComponent<CatAudio>();
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        _isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, groundLayer);
        horizontalInput = Input.GetAxisRaw("Horizontal");
        jumpButtonPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);

        HandleAllJumping();
    }

    private void FixedUpdate()
    {
        if (!_isWallJumping)
        {
            playerRigidbody.linearVelocity = new Vector2(horizontalInput * moveSpeed, playerRigidbody.linearVelocityY);
            playerVelocity = playerRigidbody.linearVelocity; ;
        }

    }

    private void HandleAllJumping()
    {

        if (jumpButtonPressed && _isGrounded)
        {
            playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocityX, jumpForce);
            catAudio?.PlayJumpSound();

        } else if (jumpButtonPressed && _isTouchingWall)
        {
            HandleWallJump();
            catAudio?.PlayJumpSound();
        }
        
    }

    private void HandleWallJump()
    {
        _isWallJumping = true;
        float pushPlayerDirection = transform.position.x < wallCheck.position.x ? -1 : 1;

        playerRigidbody.linearVelocity = new Vector2(pushPlayerDirection * moveSpeed, jumpForce);

        Invoke(nameof(ResetWallJump), 0.2f);
    }

    private void ResetWallJump()
    {
        _isWallJumping = false;
    }

}


