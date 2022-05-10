using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public int min = 3;
    public int max = 5;
   
    public Grid background;
    private bool canCloseDialogue = false;  


    void Start()
    {
        background.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Dialogue.dialogueMngr.GetIndex() > max && Dialogue.dialogueMngr.GetDuringDialogue() && canCloseDialogue)
        {
            EndDialogue();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        Time.timeScale = 0;
        canCloseDialogue = true;

        Dialogue.dialogueMngr.SetIndex(min);
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
