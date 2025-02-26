using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Required if using TextMeshPro

public class Timer : MonoBehaviour
{
    public float startTime = 120f; // Default start time (2 minutes)
    private float timeRemaining;
    public TextMeshProUGUI timerText; // Drag a TMP text object from UI here

    private bool timerRunning = true; // Ensures the timer runs

    void Start()
    {
        ResetTimer(); // Initialize the timer when the game starts
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                RestartLevel();
            }
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60); 
            int seconds = Mathf.FloorToInt(timeRemaining % 60); 

            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            if (timeRemaining < 5)
            {
                timerText.color = Color.red; 
            }
        }
    }

    void RestartLevel()
    {
        Debug.Log("Time's up! Restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void ToggleTimer(bool isPaused)
    {
        timerRunning = !isPaused;
    }

    public void ResetTimer()
    {
        timeRemaining = startTime; 
        timerRunning = true; 
        UpdateTimerUI();
    }

}
