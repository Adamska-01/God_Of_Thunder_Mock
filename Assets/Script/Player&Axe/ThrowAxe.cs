using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAxe : MonoBehaviour
{
    public Animator myAnim;
    public float speed;

    public bool isReturning;
    private bool isClicked;
    public bool isThrowing;

    private bool canThrow = true;

    public GameObject Hammer;
    private GameObject HammerClone;
    private PlayerStats playerStats;

    //timer (in case the hammer does not return)
    private float currentTime;
    private float interval = 7;


    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        if (isClicked)
        {
            //Facing right
            if ((myAnim.GetFloat("LastMoveX") + myAnim.GetFloat("LastMoveY")) >= 0.1f &&
                myAnim.GetFloat("LastMoveX") > myAnim.GetFloat("LastMoveY"))
            {
                HammerClone = Instantiate(Hammer, transform.position, 
                    Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            //Facing left
            if ((myAnim.GetFloat("LastMoveX") + myAnim.GetFloat("LastMoveY")) <= -0.1f &&
                    myAnim.GetFloat("LastMoveX") < myAnim.GetFloat("LastMoveY"))
            {
                HammerClone = Instantiate(Hammer, transform.position, 
                    Quaternion.Euler(new Vector3(0, 0, 180)));
            }
            //Facing up
            if ((myAnim.GetFloat("LastMoveY") + myAnim.GetFloat("LastMoveX")) >= 0.1f &&
                myAnim.GetFloat("LastMoveY") > myAnim.GetFloat("LastMoveX"))
            {
                HammerClone = Instantiate(Hammer, transform.position, 
                    Quaternion.Euler(new Vector3(0, 0, 90)));
            }
            //Facing down
            if ((myAnim.GetFloat("LastMoveY") + myAnim.GetFloat("LastMoveX")) <= -0.1f &&
                myAnim.GetFloat("LastMoveY") < myAnim.GetFloat("LastMoveX"))
            {
                HammerClone = Instantiate(Hammer, transform.position,
                    Quaternion.Euler(new Vector3(0, 0, 270)));
            }
            //idle
            if (myAnim.GetFloat("LastMoveY") == -0f &&
                myAnim.GetFloat("LastMoveY") == 0f)
            {
                HammerClone = Instantiate(Hammer, transform.position, 
                    Quaternion.Euler(new Vector3(0, 0, 270)));
            }
            //Timer for eventual return bug
            currentTime = 0;

            SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Whoosh);

            isClicked = false;
        }

        if (isThrowing && HammerClone != null)
        {
            HammerClone.GetComponent<Rigidbody2D>().velocity = 
                HammerClone.transform.TransformDirection(Vector2.right * speed);
        }
        
        if (isReturning)
        {
            //prevents hammer not returning bug
            currentTime += Time.deltaTime;
            if(currentTime > interval)
            {
                Destroy(HammerClone);
                isReturning = false;
            }


            Vector2 dir = (transform.position - HammerClone.transform.position).normalized;
            HammerClone.GetComponent<Rigidbody2D>().velocity = dir * speed; 

            if(Vector3.Distance(transform.position, HammerClone.transform.position) < 0.1f)
            {
                Destroy(HammerClone);
                isReturning = false;
            }
        }

        if(HammerClone == null)
        {
            isThrowing = false;
            isReturning = false;
            isClicked = false;
        }
    }

    public void toggleThrow()
    {
        canThrow = !canThrow;
    }

    public void PressAttackButton()
    {
        if (canThrow && !isClicked && !isThrowing && !isReturning
             && !playerStats.IsDead())
        {
            isClicked = true;
            isThrowing = true;
        }
    }
}
