using UnityEngine;
using TMPro;

public class CoinTextUI : MonoBehaviour
{

    public TextMeshProUGUI coinText;

    void Start()
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
