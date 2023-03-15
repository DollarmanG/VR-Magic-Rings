using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip audioClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(audioClip);
    }
}