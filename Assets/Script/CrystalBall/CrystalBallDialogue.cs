using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBallDialogue : MonoBehaviour
{
    public int indexMin = 8;
    public int indexMax = 8;

    public Grid background;
    private bool canCloseDialogue = false;

    private int cnt = 0; //the dialogue happens only once


    void Start()
    {
        background.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Dialogue.dialogueMngr.GetIndex() > indexMax && Dialogue.dialogueMngr.GetDuringDialogue() && canCloseDialogue)
        {
            EndDialogue();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && cnt <= 0)
        {
            StartDialogue();
            ++cnt;
        }
    }

    private void StartDialogue()
    {
        Time.timeScale = 0;
        canCloseDialogue = true;

        Dialogue.dialogueMngr.SetIndex(indexMin);
        background.gameObject.SetActive(true);
        Dialogue.dialogueMngr.ToggleDuringDialogue();
        Dialogue.dialogueMngr.ToggleText();
        Dialogue.dialogueMngr.StartDialogue();
    }

    private void EndDialogue()
    {
        Dialogue.dialogueMngr.ToggleText();
        Dialogue.dialogueMngr.ToggleDuringDialogue();
        background.gameObject.SetActive(false);

        Dialogue.dialogueMngr.ResetText();

        Time.timeScale = 1;
        canCloseDialogue = false;
    }
}
