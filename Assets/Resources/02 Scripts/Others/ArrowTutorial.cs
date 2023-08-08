using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class ArrowTutorial : MonoBehaviour
{
    public float animLenth;
    public float scaleValue;
    public Vector3 direction;
    public float distance;

    private GameObject blockHolder;
    public List<Transform> blocks;
    private void Awake()
    {
        blockHolder = GameObject.FindGameObjectWithTag("BlockHolder");
        DoAnim();
    }
    private void OnEnable()
    {
        SetActiveBlock();
    }
    void DoAnim()
    {
        transform.DOScale(scaleValue, animLenth).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
        Vector3 pos = transform.position + direction.normalized * distance;
        transform.DOMove(pos, animLenth).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    public void SetActiveBlock()
    {
        foreach(Transform block in blockHolder.transform)
        {
            block.gameObject.SetActive(false);
        }
        foreach (Transform block in blocks)
        {
            block.gameObject.SetActive(true);
        }
    }
}
