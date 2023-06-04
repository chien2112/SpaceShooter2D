using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] float currentHp;
    [SerializeField] float moveSpeed;
    [SerializeField] float extraSpeedMultiplier;

    public List<Weapon> weapons = new List<Weapon>();
    public List<Sprite> sprites = new List<Sprite>();

    private void Update()
    {
        Move();
        Shoot();
    }
    void Move()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var extraSpeed = Vector2.Distance(mousePos, transform.position);
        extraSpeed *= extraSpeedMultiplier;
        var speed = (moveSpeed + extraSpeed) / 1000;
        transform.position = Vector2.MoveTowards(transform.position, mousePos, speed);

    }
    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            foreach (Weapon wp in weapons)
            {
                wp.DoShoot();
            }
        }
    }

}


