using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startTime = 120f; 
    private float timeRemaining;
    public TextMeshProUGUI timerText; 

    private bool timerRunning = true;

    void Start()
    {
        ResetTimer(); 
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
