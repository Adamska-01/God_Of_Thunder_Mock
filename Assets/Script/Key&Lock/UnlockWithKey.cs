using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWithKey : MonoBehaviour
{
    private PlayerStats playerJewel;
    private bool keyIsUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerJewel = FindObjectOfType<PlayerStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && //pay if owns at least 1 key
            playerJewel.GetKeysValue() >= 1)
        {
            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Unlock);

            playerJewel.PayWithKeys(1);
            gameObject.SetActive(false);

            keyIsUsed = true;
        }
        else if (collision.gameObject.CompareTag("Player") && //if not, warning dialogue
            playerJewel.GetKeysValue() < 1)
        {
            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Negative);

            GetComponent<KeyDialogue>().StartDialogue();
        }
    }

    public bool IsKeyUsed()
    {
        return keyIsUsed;
    }
}
