using UnityEngine;
using System.Collections;
public class ElectricManager : MonoBehaviour
{
    public static ElectricManager Instance;

    public bool playerOnSwitch1 = false;
    public bool playerOnSwitch2 = false;
    public bool enemyOnSwitch1 = false;
    public bool enemyOnSwitch2 = false;

    public bool gateOpened = false;
    private bool isMoving = false;
    public float WaitTime = 1f;
    
    private ObjectAnimation gateAnimation;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        GameObject Gate = GameObject.Find("Gate1");
        gateAnimation = Gate.GetComponent<ObjectAnimation>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckGateCondition();
    }

    public void CheckGateCondition()
    {
        if ((playerOnSwitch1 && enemyOnSwitch2) || (playerOnSwitch2 && enemyOnSwitch1))
        {
            if (!gateOpened && !isMoving)
            {
                StartCoroutine(OpenGate());
            }
        }
        else if (gateOpened && !isMoving && (!playerOnSwitch1 && !playerOnSwitch2 || !enemyOnSwitch1 && !enemyOnSwitch2))
        {
            Invoke("StartCloseGate", WaitTime);
        }
    }

    void StartCloseGate()
    {
        if (!isMoving && gateOpened)
        {
            StartCoroutine(CloseGate());
        }
    }

    IEnumerator OpenGate()
    {
        isMoving = true;
        gateOpened = true;

        if (audioSource != null)
        {
            audioSource.Play();
        }

        yield return StartCoroutine(gateAnimation.MoveDown());
        isMoving = false;
    }

    IEnumerator CloseGate()
    {
        isMoving = true;
        yield return StartCoroutine(gateAnimation.MoveUp());
        isMoving = false;
        gateOpened = false;
    }
}
