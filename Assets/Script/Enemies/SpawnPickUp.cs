using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickUp : MonoBehaviour
{
    [Range(0,1)]
    public float PotionPercentage = 0.2f;       //20%   
    [Range(0, 1)]
    public float ApplePercentage = 0.15f;       //15%   
    [Range(0, 1)]
    public float RottenApplePercentage = 0.1f;  //10%

    public enum pickup
    {
        Potion,
        Apple,
        RottenApple
    }

    public List<pickup> pickUpName = new List<pickup>();
    public List<GameObject> pickUp = new List<GameObject>();
    
    public Dictionary<pickup, GameObject> PickUps = new Dictionary<pickup, GameObject>();

    public static SpawnPickUp PickUpSpwaner;


    void Start()
    {
        PickUpSpwaner = this;

        //Build dictionary
        for (int i = 0; i < pickUp.Count; i++)
        {
            PickUps.Add(pickUpName[i], pickUp[i]);
        }
    }

    public GameObject spawnPickUp(Transform spawnPoint)
    {
        if (Random.value < PotionPercentage)
        {
            return Instantiate(PickUps[pickup.Potion], spawnPoint.position, Quaternion.identity) as GameObject;
        }
        else if (Random.value < ApplePercentage)
        {
            return Instantiate(PickUps[pickup.Apple], spawnPoint.position, Quaternion.identity) as GameObject;
        }
        else if (Random.value < RottenApplePercentage)
        {
            return Instantiate(PickUps[pickup.RottenApple], spawnPoint.position, Quaternion.identity) as GameObject;
        }

        return null;
    }
}
