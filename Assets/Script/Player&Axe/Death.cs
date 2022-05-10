using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private float interval2 = 0.01f;

    private PlayerStats playerStats;
    private float currentTime;
    private float interval = 2;

    private bool DoneItOnce = false;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStats.IsDead())
        {
            if(!DoneItOnce)
            {
                SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Death);
                DoneItOnce = true;
            }

            currentTime += Time.deltaTime;

            if(currentTime > interval)
            {
                //1) Respawn player
                playerStats.Respawn();

                //2) Respawn Enemies (by triggering a trigger collider)
                StartCoroutine(EnemiesRespawner(interval2));

                DoneItOnce = false;
                currentTime = 0;
            }
        }
    }

    IEnumerator EnemiesRespawner(float x)
    {
        for (int i = 0; i < 10; i++)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            yield return new WaitForSeconds(x);
            GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }
}
