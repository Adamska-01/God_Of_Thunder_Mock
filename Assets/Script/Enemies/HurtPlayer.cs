using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!FindObjectOfType<PlayerStats>().GetInvincible())
                SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.PlayerHurt);

            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(
               gameObject.GetComponent<EnemyHealthManager>().GetDamgeValue());
        }
    }
}
