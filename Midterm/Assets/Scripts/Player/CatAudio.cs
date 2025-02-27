using UnityEngine;

public class CatAudio : MonoBehaviour
{

    public Sounds _footsteps;
    public Sounds _meows;
    public Sounds _death;

    private AudioSource _audioSource;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootstep()
    {
        int randomIndex = Random.Range(0, _footsteps.clip.Length);
        _audioSource.PlayOneShot(_footsteps.clip[randomIndex], _footsteps.volume);
    }

    public void PlayJumpSound()
    {
        int randomIndex = Random.Range(0, _meows.clip.Length);
        _audioSource.PlayOneShot(_meows.clip[randomIndex], _meows.volume);  
    }

    public void PlayDeathSound()
    {
        _audioSource.PlayOneShot(_death.clip[0], _death.volume);
    }
}
