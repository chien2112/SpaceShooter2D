using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour, IPickable
{
    public float value;
    private Rigidbody2D rb;

    public void Pickup(Player player)
    {
        Debug.Log("pick");
        player.CurHealth += value;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.tag = "Item";
    }
    private void OnEnable()
    {
        float rand = Random.Range(0.1f, 0.2f);
        rb.gravityScale = rand;
    }
}
