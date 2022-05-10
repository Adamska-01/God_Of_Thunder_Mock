using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeReturn : MonoBehaviour
{
    private ThrowAxe pivot;
    private int cnt = 1;
    private LayerMask LogMask = 13;

    private void Start()
    {
        pivot = GameObject.Find("HammerPos").GetComponent<ThrowAxe>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Unwalkable" || collision.gameObject.tag == "Enemy")
        {
            if(collision.gameObject.CompareTag("Unwalkable"))
                SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.HammerHit);
            else
                SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.HitEnemy);

            pivot.isReturning = true;
            pivot.isThrowing = false;
            pivot.GetComponent<ThrowAxe>().Hammer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            if (cnt == 1) //allows flip only once
            {
                transform.Rotate(new Vector3(0, 0, 180));
                --cnt;
            }
        }
        if(collision.gameObject.layer == LogMask)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unwalkable")
        {
            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.HammerHit);

            pivot.GetComponent<ThrowAxe>().isReturning = true;
            pivot.GetComponent<ThrowAxe>().isThrowing = false;
            pivot.GetComponent<ThrowAxe>().Hammer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            if (cnt == 1) //allows flip only once
            {
                transform.Rotate(new Vector3(0, 0, 180));
                --cnt;
            }
        }
    }
}
