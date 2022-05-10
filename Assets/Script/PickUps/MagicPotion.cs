using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPotion : MonoBehaviour
{
    public int magicValue;
    private PlayerStats playerStats;


    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Potion);

            playerStats.TakeMagic(magicValue);
            Destroy(gameObject);
        }
    }
}
