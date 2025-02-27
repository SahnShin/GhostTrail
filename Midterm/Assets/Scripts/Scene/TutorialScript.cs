using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialScript : MonoBehaviour
{
    public GameObject[] popUpMessages;
    public ProximityDetector proximityDetector;


    void Start()
    {
        popUpMessages[0].SetActive(true);
        popUpMessages[1].SetActive(false);

    }

    void Update()
    {
        HandleMovementInstructions();
        ShowDangerInstructions();

    }

    private void HandleMovementInstructions()
    {

        bool movementKeysPressed = (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||
        Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow));
        if (movementKeysPressed)
        {
            popUpMessages[0].SetActive(false);

        }
    }

    private void ShowDangerInstructions()
    {
        if (proximityDetector.IsPlayerNearby)
        {
            popUpMessages[1].SetActive(true);
        } else
        {
            popUpMessages[1].SetActive(false);
        }
    }
}
