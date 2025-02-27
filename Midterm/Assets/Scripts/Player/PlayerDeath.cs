using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private bool _isDead = false;
    Animator animator;
    public float deathAnimationDelay = 0.2f;
    public Transform respawnPoint;
    public GameObject Timer;
    private Timer timerScript;

    public GameObject shadowPrefab;
    private MovementRecorder movementRecorder;
    private GameObject currentShadow;
    private CatAudio catAudio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        movementRecorder = GetComponent<MovementRecorder>();
        timerScript = Timer.GetComponent<Timer>();
        catAudio = GetComponent<CatAudio>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("KillingObjects") || collision.CompareTag("Enemy")) && !_isDead)
        {
            _isDead = true;
            catAudio.PlayDeathSound();
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        
        animator.SetBool("isDead", _isDead);
        timerScript.ResetTimer();

        yield return new WaitForSeconds(deathAnimationDelay);
        animator.SetBool("isDead", false);
        _isDead = false;


        List<Vector3> shadowMovement = new List<Vector3>(movementRecorder.recordedPositions);
        List<Vector2> shadowDirections = new List<Vector2>(movementRecorder.recordedDirections);

        if (shadowMovement.Count > 1)
        {
            if (currentShadow)
            {
                Destroy(currentShadow);
            }

            currentShadow = Instantiate(shadowPrefab, shadowMovement[0], Quaternion.identity);
            currentShadow.GetComponent<ShadowController>().StartReplay(shadowMovement, shadowDirections);
        }

        movementRecorder.ResetRecordedPositions();

        transform.position = respawnPoint.position;

    }

}
