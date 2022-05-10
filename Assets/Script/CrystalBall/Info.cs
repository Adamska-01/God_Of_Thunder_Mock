using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public int min = 0;
    public int max = 2;

    public Grid background;
    private bool canCloseDialogue = false;

    // Start is called before the first frame update
    void Start()
    {
        background.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Dialogue.dialogueMngr.GetIndex() > max && Dialogue.dialogueMngr.GetDuringDialogue() && canCloseDialogue)
        {
            Dialogue.dialogueMngr.ToggleText();
            Dialogue.dialogueMngr.ToggleDuringDialogue();
            background.gameObject.SetActive(false);

            Dialogue.dialogueMngr.ResetText();

            Time.timeScale = 1;
            canCloseDialogue = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            canCloseDialogue = true;

            Dialogue.dialogueMngr.SetIndex(min);
            background.gameObject.SetActive(true);
            Dialogue.dialogueMngr.ToggleDuringDialogue();
            Dialogue.dialogueMngr.ToggleText();
            Dialogue.dialogueMngr.StartDialogue();
        }
    }
}
