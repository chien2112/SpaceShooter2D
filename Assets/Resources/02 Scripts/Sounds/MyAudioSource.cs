using UnityEngine;

public class MyAudioSource : MonoBehaviour
{
    public AudioSource audioSource;
    public float lengthOfClip;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
