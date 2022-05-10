using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinCond : MonoBehaviour
{
    public Grid background;
    public UnlockWithKey keyLock;

    public GameObject endtext;

    private bool DoneItOnce = false;

    void Start()
    {
        background.gameObject.SetActive(false);

        endtext.gameObject.SetActive(false);
    }

    void Update()
    {
        if (keyLock.IsKeyUsed())
        {
            background.gameObject.SetActive(true);
            endtext.gameObject.SetActive(true);

            if(!DoneItOnce)
            {
                Time.timeScale = 0;
                MusicControl.controlMusic.transitToNoMusic();
                SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Victory);

                DoneItOnce = true;
            }
        }
    } 
}
