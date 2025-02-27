using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject exitVerificationUI;
    public GameObject levelSelector;
    public int sceneNumber;
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
        if (levelSelector != null)
        {
            levelSelector.SetActive(false);
        }

        if (Time.timeScale == 0f)
        {
            ResumeGame();
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
        ResumeGame();
        FindFirstObjectByType<LoadingScreen>().LoadScene(sceneNumber);
    }

    public void TitleScreen()
    {
        ResumeGame();
        FindFirstObjectByType<LoadingScreen>().LoadScene(0);
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

    public void GoToLevel(int sceneNumber)
    {
        ResumeGame();
        FindFirstObjectByType<LoadingScreen>().LoadScene(sceneNumber);
    }

    public void ToggleLevelSelector()
    {
        if (levelSelector != null)
        {
            levelSelector.SetActive(!levelSelector.activeSelf);
        }
    }
}