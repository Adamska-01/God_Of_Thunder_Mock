using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLog : MonoBehaviour
{
    public Animator LogAnim1;
    public Animator LogAnim2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hammer"))
        {
            LogAnim1.SetBool("OpenLog", !LogAnim1.GetBool("OpenLog"));
            LogAnim2.SetBool("OpenLog", !LogAnim2.GetBool("OpenLog"));
        }
    }
}
