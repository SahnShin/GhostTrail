using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public static CoinManager Instance;
    public int coinCount;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        coinCount = 0;
      
    }

    void Update()
    {

    }

    public void AddCoin()
    {

        coinCount++;

    }

}
