using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    public GameObject myAudioSource;
    private void Awake()
    {
        var result = FindObjectsOfType<SoundManager>();
        foreach (var manager in result)
        {
            if (manager != this)
                Destroy(manager.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        ObjectPooling.ClearDic();
    }
    public void PlayClip(AudioClip clip, AudioMixerGroup audioMixerGroup)
    {
        GameObject go = ObjectPooling.GetGameObjectFromPool(myAudioSource,Vector3.zero);
        MyAudioSource AS = go.GetComponent<MyAudioSource>();
        AS.transform.parent = null;
        AS.audioSource.clip = clip;
        AS.lengthOfClip = AS.audioSource.clip.length;
        AS.audioSource.outputAudioMixerGroup = audioMixerGroup;
        AS.gameObject.SetActive(true);
        AS.audioSource.PlayOneShot(clip);

        StartCoroutine(IDeactivate(AS.lengthOfClip, go));
    }
    IEnumerator IDeactivate(float length, UnityEngine.GameObject obj)
    {
        yield return new WaitForSeconds(length);
        obj.SetActive(false);
    }
}
