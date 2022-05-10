using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkunkAttack : MonoBehaviour
{
    private float Dist = 13f;
    private Vector3 direction;
    public float attackSpeed;

    public GameObject Attack;
    private GameObject AttackClone;
    public Animator myAnim;


    void Update()
    {
        //Facing right
        if ((myAnim.GetFloat("moveX") + myAnim.GetFloat("moveY")) >= 0.1f &&
            myAnim.GetFloat("moveX") > myAnim.GetFloat("moveY"))
        {
            direction = Vector3.left;
        }
        //Facing left
        if ((myAnim.GetFloat("moveX") + myAnim.GetFloat("moveY")) <= -0.1f &&
             myAnim.GetFloat("moveX") < myAnim.GetFloat("moveY"))
        {
            direction = Vector3.right;
        }
        //Facing up
        if ((myAnim.GetFloat("moveY") + myAnim.GetFloat("moveX")) >= 0.1f &&
            myAnim.GetFloat("moveY") > myAnim.GetFloat("moveX"))
        {
            direction = Vector3.down;
        }
        //Facing down
        if ((myAnim.GetFloat("moveY") + myAnim.GetFloat("moveX")) <= -0.1f &&
            myAnim.GetFloat("moveY") < myAnim.GetFloat("moveX"))
        {
            direction = Vector3.up;
        }

        //Debug.DrawLine(transform.position + direction / 2,
        //    transform.position + direction * Dist, Color.red);

        //Raycast (line of sight is on the back)
        var Hits2D = Physics2D.Raycast(transform.position + direction / 2, direction, Dist);
        if(Hits2D)
        {
            if (Hits2D.transform.CompareTag("Player") && AttackClone == null)
            {
                AttackClone = Instantiate(Attack, transform.position, transform.rotation) as GameObject;

                AttackClone.GetComponent<Rigidbody2D>().velocity = direction * attackSpeed;
            }
        }
    }
}
