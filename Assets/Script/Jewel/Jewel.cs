using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour
{
    public int jewels; //amount

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeJewels(jewels);

            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.JewelCollect);

            Destroy(gameObject);
        }
    }
}
