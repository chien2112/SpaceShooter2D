using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    [SerializeField] private Vector3 hotspot;
    [SerializeField] private Sprite cursor;
    [SerializeField] private Sprite cursorClick;
    [SerializeField] private float trailTime;
    [SerializeField] private float _trailTime;
    private SpriteRenderer spriteRenderer;
    bool isPause;
    private void Awake()
    {
        isPause = false;
        trailTime = transform.GetChild(0).GetComponent<TrailRenderer>().time;
        var result = FindObjectsOfType<CursorManager>();
        foreach (var manager in result)
        {
            if (manager != this)
                Destroy(manager.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cursor;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Time.timeScale == 0 && isPause == false)
        {
            if(_trailTime <= trailTime)
            {
                _trailTime -= Time.unscaledDeltaTime;
                if (_trailTime <= 0)
                {
                    ClearTrail();
                    _trailTime = trailTime;
                }
            }
        }
        else if(Time.timeScale == 1 && isPause == true)
        {
        }
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = 0;
        transform.position = cursorPos - hotspot;
        if (Input.GetMouseButtonDown(0))
        {
            spriteRenderer.sprite = cursorClick;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            spriteRenderer.sprite = cursor;
        }
    }

    void ClearTrail()
    {
        transform.GetChild(0).GetComponent<TrailRenderer>().Clear();  
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + hotspot, 0.05f);
    }
    private void OnApplicationFocus(bool focus)
    {
        Cursor.visible = false;
    }
}
