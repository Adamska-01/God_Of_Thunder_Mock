using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlobMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D body2d;
    private Animator myAnim;

    private float currentTime;
    private float interval1 = .2f;
    private float interval2 = 1;

    private Vector2 previousVel;

    private bool isAttacking = false;


    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > interval1 && !isAttacking) //Idle (.2f)
        {
            isAttacking = true;
            Attack();
        }
        if (currentTime > interval2) //Attack (.8f)
        {
            currentTime = 0;
            isAttacking = false;

            body2d.velocity = Vector2.zero;
            myAnim.SetBool("isAttacking", false);
            speed = Mathf.Abs(speed);
        }
    }

    public void Attack()
    {
        int dir = Random.Range(0, 4);

        if (dir == 0) //right
            body2d.velocity = Vector2.right * speed;
        else if (dir == 1) //donw
            body2d.velocity = Vector2.down * speed;
        else if (dir == 2) //left
            body2d.velocity = Vector2.left * speed;
        else if (dir == 3) //up
            body2d.velocity = Vector2.up * speed;

        myAnim.SetBool("isAttacking", true);

        previousVel = body2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Unwalkable")
            || other.gameObject.layer == 10)
        {
            body2d.velocity = -previousVel; //bounce
        }
    }
}
