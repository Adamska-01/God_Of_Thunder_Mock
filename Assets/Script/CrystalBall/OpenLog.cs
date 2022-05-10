using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLog : MonoBehaviour
{
    public Animator LogAnim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Hammer"))
        {
            LogAnim.SetBool("OpenLog", !LogAnim.GetBool("OpenLog"));
        }    
    }
}
