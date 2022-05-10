using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballAttack : MonoBehaviour
{
    public GameObject Attack;
    public float attackSpeed;
    
    private float Dist = 20;
    private GameObject AttackClone;

    void Update()
    {
        //Debug.DrawLine(transform.position + Vector3.right / 2,
        //    transform.position + Vector3.right * Dist, Color.red);
        //Debug.DrawLine(transform.position + Vector3.left / 2,
        //    transform.position + Vector3.left * Dist, Color.red);
        //Debug.DrawLine(transform.position + Vector3.up / 2,
        //    transform.position + Vector3.up * Dist, Color.red);
        //Debug.DrawLine(transform.position + Vector3.down / 2,
        //    transform.position + Vector3.down * Dist, Color.red);

        //var Hits2DRight = Physics2D.Raycast(transform.position + Vector3.right, Vector3.right, Dist);
        //var Hits2DLeft = Physics2D.Raycast(transform.position + Vector3.left, Vector3.left, Dist);
        //var Hits2DUp = Physics2D.Raycast(transform.position + Vector3.up, Vector3.up, Dist);
        //var Hits2DDown = Physics2D.Raycast(transform.position + Vector3.down, Vector3.down, Dist);
        
        //if(Hits2DRight)
        //{
        //    if(Hits2DRight.transform.CompareTag("Player") && AttackClone == null)
        //    {
        //        AttackClone = Instantiate(Attack, transform.position, transform.rotation) as GameObject;

        //        AttackClone.GetComponent<Rigidbody2D>().velocity = Vector2.right * attackSpeed;
        //    }
        //}
        //if (Hits2DLeft)
        //{
        //    if (Hits2DLeft.transform.CompareTag("Player") && AttackClone == null)
        //    {
        //        AttackClone = Instantiate(Attack, transform.position, transform.rotation) as GameObject;

        //        AttackClone.GetComponent<Rigidbody2D>().velocity = Vector2.left * attackSpeed;
        //    }
        //}
        //if (Hits2DUp)
        //{
        //    if (Hits2DUp.transform.CompareTag("Player") && AttackClone == null)
        //    {
        //        AttackClone = Instantiate(Attack, transform.position, transform.rotation) as GameObject;

        //        AttackClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * attackSpeed;
        //    }
        //}
        //if (Hits2DDown)
        //{
        //    if (Hits2DDown.transform.CompareTag("Player") && AttackClone == null)
        //    {
        //        AttackClone = Instantiate(Attack, transform.position, transform.rotation) as GameObject;

        //        AttackClone.GetComponent<Rigidbody2D>().velocity = Vector2.down * attackSpeed;
        //    }
        //}


        var Hits2DRight = Physics2D.RaycastAll(transform.position, Vector2.right, Dist);
        var Hits2DLeft = Physics2D.RaycastAll(transform.position, Vector2.left, Dist);
        var Hits2DUp = Physics2D.RaycastAll(transform.position, Vector2.up, Dist);
        var Hits2DDown = Physics2D.RaycastAll(transform.position, Vector2.down, Dist);

        //Debug.DrawLine(transform.position,
        //    transform.position + new Vector3(Dist, 0, 0), Color.red);
        //Debug.DrawLine(transform.position,
        //    transform.position + new Vector3(-Dist, 0, 0), Color.red);
        //Debug.DrawLine(transform.position,
        //    transform.position + new Vector3(0, -Dist, 0), Color.red);
        //Debug.DrawLine(transform.position,
        //    transform.position + new Vector3(0, Dist, 0), Color.red);

        foreach (var item in Hits2DRight)
        {
            if (item.transform.tag == "Player")
            {
                if(AttackClone == null)
                {
                    AttackClone = Instantiate(Attack, transform.position, transform.rotation) as GameObject;
    
                    AttackClone.GetComponent<Rigidbody2D>().velocity = Vector2.right * attackSpeed;
                }
            }
        }
        foreach (var item in Hits2DLeft)
        {
            if (item.transform.CompareTag("Player"))
            {
                if (AttackClone == null)
                {
                    AttackClone = Instantiate(Attack, transform.position, transform.rotation) as GameObject;

                    AttackClone.GetComponent<Rigidbody2D>().velocity = Vector2.left * attackSpeed;
                }
            }
        }
        foreach (var item in Hits2DUp)
        {
            if (item.transform.CompareTag("Player"))
            {
                if (AttackClone == null)
                {
                     AttackClone = Instantiate(Attack, transform.position, transform.rotation) as GameObject;

                     AttackClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * attackSpeed;
                }
            }
        }
        foreach (var item in Hits2DDown)
        {
            if (item.transform.CompareTag("Player"))
            {
                if (AttackClone == null)
                {
                    AttackClone = Instantiate(Attack, transform.position, transform.rotation) as GameObject;

                    AttackClone.GetComponent<Rigidbody2D>().velocity = Vector2.down * attackSpeed;
                }
            }
        }

    }
}
