using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen; 
    public Slider progressBar;

    public void LoadScene(int sceneNumber)
    {
        StartCoroutine(LoadSceneAsync(sceneNumber));
    }

    IEnumerator LoadSceneAsync(int sceneNumber)
    {
        loadingScreen.SetActive(true); 
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNumber);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress; 

            if (operation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(.5f);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
