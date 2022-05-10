using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public bool canPush = false;
    public float speed;

    //raycast
    public float Dist;
    public float startDist;

    private Rigidbody2D body2D;


    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if (canPush)
        {
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
                //right 
                if (item.transform.tag == "Player")
                {
                    body2D.MovePosition(body2D.position + Vector2.left * speed * Time.deltaTime);
                }
            }
            foreach (var item in Hits2DLeft)
            {
                if (item.transform.CompareTag("Player"))
                {
                    body2D.MovePosition(body2D.position + Vector2.right * speed * Time.deltaTime);
                }
            }
            foreach (var item in Hits2DUp)
            {
                if (item.transform.CompareTag("Player"))
                {
                    body2D.MovePosition(body2D.position + Vector2.down * speed * Time.deltaTime);
                }
            }
            foreach (var item in Hits2DDown)
            {
                if (item.transform.CompareTag("Player"))
                {
                    body2D.MovePosition(body2D.position + Vector2.up * speed * Time.deltaTime);
                }
            }

            body2D.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canPush = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canPush = false;
    }
}
