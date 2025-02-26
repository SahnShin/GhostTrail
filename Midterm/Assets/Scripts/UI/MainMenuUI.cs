using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public TextMeshProUGUI titleText; 
    public float fadeDuration = 3f;
    public GameObject TutorialUI;

    void Start()
    {
        StartCoroutine(DelayedFadeIn());
        if (TutorialUI != null)
        {
            TutorialUI.SetActive(false);
        }
    }

    IEnumerator DelayedFadeIn()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(FadeInText());
    }

    IEnumerator FadeInText()
    {
        Color textColor = titleText.color;
        textColor.a = 0; 
        titleText.color = textColor;

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            textColor.a = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            titleText.color = textColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textColor.a = 1;
        titleText.color = textColor;
    }

    public void StartGame()
    {
        FindFirstObjectByType<LoadingScreen>().LoadScene(1);
    }

    public void ToggleTutorial()
    {
        if (TutorialUI != null)
        {
            TutorialUI.SetActive(!TutorialUI.activeSelf);
        }
    }
}
