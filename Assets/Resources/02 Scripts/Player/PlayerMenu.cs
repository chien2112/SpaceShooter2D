using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float extraSpeedMultiplier;

    public List<Weapon> weapons = new List<Weapon>();
    public List<Sprite> sprites = new List<Sprite>();

    private void Awake()
    {
        Weapon[] wps = FindObjectsOfType<Weapon>();
        foreach(Weapon weapon in wps)
        {
            weapons.Add(weapon);
        }
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var extraSpeed = Vector2.Distance(mousePos, transform.position);
        extraSpeed *= extraSpeedMultiplier;
        var speed = (moveSpeed + extraSpeed) / 1000;
        transform.position = Vector2.MoveTowards(transform.position, mousePos, speed);

    }

}
