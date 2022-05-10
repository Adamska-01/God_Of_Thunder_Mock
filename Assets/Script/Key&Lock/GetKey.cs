using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Key);

            collision.gameObject.GetComponent<PlayerStats>().TakeKey(1); //adds 1 key

            gameObject.SetActive(false);
        }
    }
}
