using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gass : MonoBehaviour
{
    public int damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!FindObjectOfType<PlayerStats>().GetInvincible())
                SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.PlayerHurt);

            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Unwalkable")
        {
            Destroy(gameObject);
        }
    }
}
