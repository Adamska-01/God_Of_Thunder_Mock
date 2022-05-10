using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Joystick joystick;

    private Vector3 direction = Vector3.zero;

    private bool canMove = true;
    private Animator anim;
    private Rigidbody2D body2D;
    private PlayerStats playerStats;


    void Start()
    {
        anim = GetComponent<Animator>();
        body2D = GetComponent<Rigidbody2D>();

        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (canMove && !playerStats.IsDead())
        {
            direction.x = joystick.Horizontal;
            direction.y = joystick.Vertical;


            //set animation
            anim.SetFloat("moveX", direction.x);
            anim.SetFloat("moveY", direction.y);

            //Set idle position
            if (joystick.Horizontal >= 0.1f ||
                joystick.Horizontal <= -0.1f ||
                joystick.Vertical >= 0.1f ||
                joystick.Vertical <= -0.1f)
            {
                anim.SetFloat("LastMoveX", joystick.Horizontal);
                anim.SetFloat("LastMoveY", joystick.Vertical);
            }


            direction.Normalize();

            direction *= speed;

            body2D.velocity = direction;
        }
        else
        {
            body2D.velocity = Vector2.zero;
        }
    }

    //Set During transitions between zones
    public void toggleMovement()
    {
        canMove = !canMove;
    }
}
