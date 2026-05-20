using UnityEngine;

public class Music : MonoBehaviour
{
    // Reference to the AudioSource component
    public AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Start playing music
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
