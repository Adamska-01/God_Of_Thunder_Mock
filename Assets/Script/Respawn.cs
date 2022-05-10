using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.CompareTag("Enemy"))
                    child.GetComponent<RespawnEntity>().RespaawnEnemy();
                else if (child.gameObject.name.Contains("Log"))
                    child.GetComponent<Animator>().SetBool("OpenLog", false);
                else
                    child.GetComponent<RespawnEntity>().RespawnObject();
            }  
        }
    }
}
