using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainMagic : MonoBehaviour
{
    public int exchangeHealth;
    public int exchangeMagic;

    //Timer
    private float currentTime = 0;
    private float interval = 0.5f;

    private PlayerStats playerStats;
    private bool buttonIsPressed = false;

    private AudioSource clip;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        if(buttonIsPressed && !playerStats.IsDead())
        {
            currentTime += Time.deltaTime;

            if(currentTime > interval && playerStats.GetMagicValue() > 0
                && playerStats.GetHealthValue() < playerStats.HealthBar.maxValue
                && playerStats.HasItem())
            {
                if(clip == null)
                    clip = SFXManager.GlobalAudioMix.PlayAndReturnSFX(SFXManager.SFXType.DrainMagic);

                playerStats.Heal(exchangeHealth);
                playerStats.UseMagic(exchangeMagic);
  
                currentTime = 0;
            }
            else if(playerStats.GetMagicValue() <= 0 && !playerStats.HasItem() && 
                playerStats.GetHealthValue() >= playerStats.HealthBar.maxValue)
            {
                if (clip == null)
                    clip = SFXManager.GlobalAudioMix.PlayAndReturnSFX(SFXManager.SFXType.Negative);
            }
        }
    }

    //button trigger event
    public void onPress()
    {
        buttonIsPressed = true;
    }

    public void onRelease()
    {
        buttonIsPressed = false;
    }
}
