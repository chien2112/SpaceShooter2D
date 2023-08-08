using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;

public class NotificationText : MonoBehaviour
{
    public float fadeInLength;
    public float fadeOutLength;
    public float waitTime;
    public Vector3 direction;
    private Vector3 startPosition;
    private void Awake()
    {
        startPosition = transform.position;
    }
    private void OnEnable()
    {
        transform.position = startPosition;
        FadeIn();
    }
    void FadeIn()
    {
        GetComponent<TextMeshProUGUI>().alpha = 0;
        GetComponent<TextMeshProUGUI>().DOFade(1, fadeInLength).SetEase(Ease.Linear).OnComplete(() => StartCoroutine(FadeOut()));
    }
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1f);
        Vector3 pos = transform.position + direction;
        transform.DOMove(pos, fadeOutLength).SetEase(Ease.Linear);
        GetComponent<TextMeshProUGUI>().DOFade(0, fadeOutLength).SetEase(Ease.Linear).OnComplete(()=>gameObject.SetActive(false));
    }
    private void OnDisable()
    {
        
    }
}
