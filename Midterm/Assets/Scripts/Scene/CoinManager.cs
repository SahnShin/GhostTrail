using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public static CoinManager Instance;
    public int coinCount;

    private GameObject player;

    CoinCounter coinCounter;

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
        player = GameObject.FindGameObjectWithTag("Player");
        coinCounter = player.GetComponent<CoinCounter>();
    }

    void Update()
    {
        coinCount = coinCounter.CoinCount;
    }
}
