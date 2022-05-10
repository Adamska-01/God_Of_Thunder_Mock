using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEntity : MonoBehaviour
{
    private Vector3 startPos;
    private EnemyHealthManager enemyHealth;


    void Start()
    {
        startPos = transform.position;

        //in case it s an enemy
        enemyHealth = GetComponent<EnemyHealthManager>();
    }
    
    //for all enemies 
    public void RespaawnEnemy()
    {
        gameObject.SetActive(true);
        enemyHealth.SetHealth();
        transform.position = startPos;

        //destroys any pick up left from the enemy
        if(enemyHealth.GetPickUp() != null) 
            Destroy(enemyHealth.GetPickUp());
    }

    //for objects and NPC
    public void RespawnObject()
    {
        gameObject.SetActive(true);
        transform.position = startPos;
    }
}
