//using UnityEngine;

//public class ShadowAnimation : MonoBehaviour
//{
//    private Animator animator;

//    private Vector2 velocity;
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        animator = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    public void UpdateAnimation(Vector2 shadowDirection)
//    {
//        bool isWalking = Mathf.Abs(shadowDirection.x) > 0.1f;
//        animator.SetBool("isWalking", isWalking);
//        bool isJumping = shadowDirection.y > 0.1f;
//        animator.SetBool("isJumping", isJumping);

//        if (!isWalking && !isJumping)
//        {
//            animator.SetBool("isIdle", true);
//        }
//        else
//        {
//            animator.SetBool("isIdle", false);
//        }
//    }

    
//}
