using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour
{
    protected Button button;
    [SerializeField] protected AudioClip clip;
    [SerializeField] protected AudioMixerGroup audioMixerGroup;
    protected virtual void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickButton);
    }
    protected virtual void ClickButton()
    {
        SoundManager.Instance.PlayClip(clip, audioMixerGroup);
    }
}
