using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    [SerializeField] private Vector3 hotspot;
    [SerializeField] private Sprite cursor;
    [SerializeField] private Sprite cursorClick;
    private SpriteRenderer spriteRenderer;
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
        spriteRenderer.sprite = cursor;
        Cursor.visible = false;
    }
    private void Update()
    {
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position+hotspot, 0.05f);
    }
    private void OnApplicationFocus(bool focus)
    {
        Cursor.visible = false;
    }
}
