using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rottenApple : MonoBehaviour
{
    public int damageValue;
    private PlayerStats playerStats;


    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.PlayerHurt);

            playerStats.TakeDamageFromOther(damageValue);
            Destroy(gameObject);
        }
    }
}
