using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private void Awake()
    {
        var result = FindObjectsOfType<Music>();
        foreach (var manager in result)
        {
            if (manager != this)
                Destroy(manager.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    public void ChangeMusic(AudioClip clip)
    {
        audioSource.enabled = false;
        audioSource.clip = clip;
        audioSource.enabled = true;
    }
}
