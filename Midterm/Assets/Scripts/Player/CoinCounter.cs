using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    

    CoinManager coinManager;


    void Start()
    {
        coinManager = CoinManager.Instance;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinManager.AddCoin();
        }
    }

}
