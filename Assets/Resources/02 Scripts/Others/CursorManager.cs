using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    [SerializeField] private Vector2 hotspot;
    [SerializeField] private Sprite cursor;
    [SerializeField] private Sprite cursorClick;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isVisible;
    private void Awake()
    {
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
        isVisible = false;
        spriteRenderer.sprite = null;
        Cursor.visible = false;
    }
    public void CursorVisible(bool visible)
    {
        isVisible = visible;
        if (isVisible)
        {
            spriteRenderer.sprite = cursor;
        }
        else
        {
            spriteRenderer.sprite = null;
        }
    }
    private void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
        if (Input.GetMouseButtonDown(0) && isVisible)
        {
            spriteRenderer.sprite = cursorClick;
        }
        else if (Input.GetMouseButtonUp(0) && isVisible)
        {
            spriteRenderer.sprite = cursor;
        }
    }
    private void OnApplicationFocus(bool focus)
    {
        Cursor.visible = false;
    }
}
