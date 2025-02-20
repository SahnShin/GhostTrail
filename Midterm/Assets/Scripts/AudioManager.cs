using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string name)
    {

        foreach (Sounds sound in sounds)
        {
            if (sound.name == name)
            {
                if (sound.clip.Length > 0)
                {
                    int randomIndex = Random.Range(0, sound.clip.Length);
                    audioSource.PlayOneShot(sound.clip[randomIndex], sound.volume);
                }
            }
            
        }
    }


}
