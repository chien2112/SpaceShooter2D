using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [SerializeField] Vector3 topRight;
    [SerializeField] float width;
    [SerializeField] float height;

    private void Awake()
    {
        topRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        width = topRight.x;
        height = topRight.y;
    }
    private void Update()
    {
        CheckBoundaries();
    }
    public void CheckBoundaries()
    {
        if (transform.position.x * transform.position.x >= width * width) 
        {
            if(transform.position.x > 0)
            {
                transform.position = new Vector2(width, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(-width, transform.position.y);
            }
            
        }
        if (transform.position.y * transform.position.y >= height * height)
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector2(transform.position.x, height);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, -height);
            }
            
        }
    }
}
