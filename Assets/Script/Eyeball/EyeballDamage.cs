using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(
               GameObject.Find("Eyeball").GetComponent<EnemyHealthManager>().GetDamgeValue());

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Unwalkable" || collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }
}
