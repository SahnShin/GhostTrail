using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            coinCount = 0;
        }
    }

    public void AddCoin()
    {

        coinCount++;

    }

}
