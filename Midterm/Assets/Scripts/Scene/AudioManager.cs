using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource soundEffectSource;

    void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else Destroy(gameObject);
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        soundEffectSource.volume = volume;
        soundEffectSource.PlayOneShot(clip); 
    }
}
