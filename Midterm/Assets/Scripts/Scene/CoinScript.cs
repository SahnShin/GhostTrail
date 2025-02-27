using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  
        {
            AudioManager.Instance.PlaySound(audioSource.clip, 0.5f);
            Destroy(gameObject);
        }
    }
}
