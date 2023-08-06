using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPickable
{
    public int value;
    private Rigidbody2D rb;

    public void Pickup(Player player)
    {
        SavingSystem.Instance.dataPlayer.coin += value;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            gameObject.SetActive(false);
        }
    }
}
