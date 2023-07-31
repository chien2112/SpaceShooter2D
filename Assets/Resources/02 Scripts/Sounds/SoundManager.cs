using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    private void Awake()
    {
        var result = FindObjectsOfType<SoundManager>();
        foreach (var manager in result)
        {
            if (manager != this)
                Destroy(manager.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void PlayClip(AudioClip clip, AudioMixerGroup audioMixerGroup)
    {
        var go = ObjectPooling.GetGameObjectFromPool("MyAudioSource", "01 Prefabs/MyAudioSource/MyAudioSource");
        MyAudioSource myAudioSource = go.GetComponent<MyAudioSource>();
        myAudioSource.transform.parent = null;
        myAudioSource.audioSource.clip = clip;
        myAudioSource.lengthOfClip = myAudioSource.audioSource.clip.length;
        myAudioSource.audioSource.outputAudioMixerGroup = audioMixerGroup;
        myAudioSource.gameObject.SetActive(true);
        myAudioSource.audioSource.PlayOneShot(clip);

        StartCoroutine(IDeactivate(myAudioSource.lengthOfClip, myAudioSource.gameObject));
    }
    IEnumerator IDeactivate(float length, UnityEngine.GameObject obj)
    {
        yield return new WaitForSeconds(length);
        obj.SetActive(false);
    }
}
