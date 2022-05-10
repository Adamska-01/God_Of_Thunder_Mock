using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReward : MonoBehaviour
{
    public UnlockJewel locker;

    void Update()
    {
        //make jewels appear when the lock is unlocked
        if (locker.IsPaid())
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
