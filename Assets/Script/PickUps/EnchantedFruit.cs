using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnchantedFruit : MonoBehaviour
{
    public int magicValue;

    private Sprite Item;
    private PlayerStats playerStats;


    void Start()
    {
        Item = GetComponent<SpriteRenderer>().sprite;
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStats.TakeSpecialItem(Item);
            playerStats.TakeMagic(magicValue);
        }
    }
}
