using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public float enemyHealth;
    public float enemyMaxHealth;
    
    public int score; //get score every time you kill an enemy

    public int Damage;

    public GameObject Sparkles;

    private PlayerStats playerStats;
    private GameObject SpawnedPickUp;
   

    void Start()
    {
        enemyHealth = enemyMaxHealth;

        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        //Death
        if(enemyHealth <= 0)
        {
            playerStats.TakeScore(score);

            gameObject.SetActive(false);

            //pickup
            SpawnedPickUp = SpawnPickUp.PickUpSpwaner.spawnPickUp(transform);
            //sparkles
            Instantiate(Sparkles, transform.position, Quaternion.identity);
        }
    }

    public void HurtEnemy(float damage)
    {
        enemyHealth -= damage;
    }

    public int GetDamgeValue()
    {
        return Damage;
    }

    public void SetHealth()
    {
        enemyHealth = enemyMaxHealth;
    }

    public GameObject GetPickUp()
    {
        return SpawnedPickUp;
    }
}
