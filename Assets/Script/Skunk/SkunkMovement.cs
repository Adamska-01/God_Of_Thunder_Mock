using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkunkMovement : MonoBehaviour
{
    public float speed;
    private int dir; //random number for direction 

    private Vector2 Direction;

    private Rigidbody2D body2d;
    private Animator anim;

    //raycast
    public float Dist;
    public float startDist;


    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //start with a random direction
        Direction = ChangeDirection();
    }

    void Update()
    {
        body2d.velocity = Direction * speed;

        if (Direction == Vector2.right)
        {
            var Hits2D = Physics2D.RaycastAll(transform.position, Vector2.right, Dist);
            foreach (var item in Hits2D)
            {
                if (item.transform.CompareTag("Unwalkable"))
                {
                    Direction = ChangeDirection();
                }
            }
        }
        if (Direction == Vector2.left)
        {
            var Hits2D = Physics2D.RaycastAll(transform.position, Vector2.left, Dist);
            foreach (var item in Hits2D)
            {
                if (item.transform.CompareTag("Unwalkable"))
                {
                    Direction = ChangeDirection();
                }
            }
        }
        if (Direction == Vector2.down)
        {
            var Hits2D = Physics2D.RaycastAll(transform.position, Vector2.down, Dist);
            foreach (var item in Hits2D)
            {
                if (item.transform.CompareTag("Unwalkable"))
                {
                    Direction = ChangeDirection();
                }
            }
        }
        if (Direction == Vector2.up)
        {
            var Hits2D = Physics2D.RaycastAll(transform.position, Vector2.up, Dist);
            foreach (var item in Hits2D)
            {
                if (item.transform.CompareTag("Unwalkable"))
                {
                    Direction = ChangeDirection();
                }
            }
        }

        //Debug.DrawLine(transform.position,
        //        transform.position + new Vector3(Dist, 0, 0), Color.red);
        //Debug.DrawLine(transform.position + new Vector3(-startDist, 0, 0),
        //    transform.position + new Vector3(-Dist, 0, 0), Color.red);
        //Debug.DrawLine(transform.position + new Vector3(0, -startDist, 0),
        //    transform.position + new Vector3(0, -Dist, 0), Color.red);
        //Debug.DrawLine(transform.position + new Vector3(0, startDist, 0),
        //    transform.position + new Vector3(0, Dist, 0), Color.red);
    }

    private Vector2 ChangeDirection()
    {
        dir = Random.Range(0, 4);

        Vector2 temp = new Vector2();

        if (dir == 0) //right
        {
            anim.SetFloat("moveX", 1);
            anim.SetFloat("moveY", 0);

            temp = Vector2.right;
        }
        else if (dir == 1) //down
        {
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", -1);

            temp = Vector2.down;
        }
        else if (dir == 2) //left
        {
            anim.SetFloat("moveX", -1);
            anim.SetFloat("moveY", 0);

            temp = Vector2.left;
        }
        else if (dir == 3) //up
        {
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", 1);

            temp = Vector2.up;
        }

        return temp;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || 
            collision.gameObject.CompareTag("Player") ||
            collision.gameObject.layer == 10)
        {
            Direction = ChangeDirection();
        }
    }
}
