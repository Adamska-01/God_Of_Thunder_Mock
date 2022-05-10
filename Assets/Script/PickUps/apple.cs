using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    public int healingValue;
    private PlayerStats playerStats;


    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.AppleEat);

            playerStats.Heal(healingValue);
            Destroy(gameObject);
        }
    }
}
