using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockJewel : MonoBehaviour
{
    public int cost;

    private PlayerStats playerJewel;
    private bool isPaid = false;


    void Start()
    {
        playerJewel = FindObjectOfType<PlayerStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") &&  //pay if own enough jewels
            playerJewel.GetJewelsValue() >= cost)
        {
            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Unlock);

            playerJewel.PayWithJewels(cost);
            isPaid = true;

            gameObject.SetActive(false);
        }
        else if(collision.gameObject.CompareTag("Player") && //warning dialogue
            playerJewel.GetJewelsValue() < cost)
        {
            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Negative);

            GetComponent<JewelDialogue>().StartDialogue();
        }
    }

    public bool IsPaid()
    {
        return isPaid;
    }
}
