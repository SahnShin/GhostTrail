using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    
    private int _coinCount;
    public int CoinCount => _coinCount;


    void Start()
    {
        _coinCount = 0;
    }

    

    public void AddCoin()
    {

        _coinCount++;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            AddCoin();
        }
    }


    public void Reset()
    {
        _coinCount = 0;
    }
}
