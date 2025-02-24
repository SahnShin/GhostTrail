using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject exitVerificationUI;
    private bool isPaused = false;

    void Start()
    {
        if (menuUI != null)
        {
            menuUI.SetActive(false); 
        }
        if (exitVerificationUI != null)
        {
            exitVerificationUI.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if (menuUI != null)
        {
            menuUI.SetActive(!menuUI.activeSelf);
        }
        if (isPaused)
                ResumeGame();
            else
                PauseGame();
    }

     void PauseGame()
    {
        Time.timeScale = 0f; 
        isPaused = true; 
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; 
        isPaused = false; 
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
        ResumeGame();
    }

    public void ToggleVerification()
    {
        if (exitVerificationUI != null)
        {
            exitVerificationUI.SetActive(!exitVerificationUI.activeSelf);
        }
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}