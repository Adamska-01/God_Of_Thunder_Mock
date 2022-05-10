using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDialogue : MonoBehaviour
{
    public int indexMin = 7;
    public int indexMax = 7;

    public Grid background;
    private bool canCloseDialogue = false;


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

    public void StartDialogue()
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
