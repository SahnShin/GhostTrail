using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinTextUI : MonoBehaviour
{

    public TextMeshProUGUI coinText;

    void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnSceneUnloaded(Scene scene)
    {

    }


    void Update()
    {
        if (coinText != null)
        {
            coinText.text = CoinManager.Instance.coinCount.ToString();
        }

    }
}
