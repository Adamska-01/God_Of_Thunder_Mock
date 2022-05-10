using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Vector3 CameraChange;
    public Vector3 playerChange;

    private Vector3 startCameraPos;
    private Vector3 newCameraPos;

    private bool startTransition = false;
    [SerializeField]
    [Range(0f, 1f)]
    private float lerpPct = 0.5f;
    private int t = 0;
    public int frameCount = 100;

    private ThrowAxe throwAxe;
    private Movement movement;

    private LayerMask playerMask = 9;


    void Start()
    {
        movement = FindObjectOfType<Movement>(); ;
        throwAxe = FindObjectOfType<ThrowAxe>();
    }

    void Update()
    {
        if (startTransition)
        {
            lerpPct = (float)t / frameCount;
            Camera.main.transform.position = Vector3.Lerp(startCameraPos,
                newCameraPos, lerpPct);

            t = (t + 1) % (frameCount + 1);

            if (lerpPct >= 1)
            {
                startTransition = false;

                //enables again movement and throw
                movement.toggleMovement(); throwAxe.toggleThrow();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerMask)
        {
             collision.gameObject.transform.position += playerChange;

            //Save this position and Health for respawn (in case of death)
            FindObjectOfType<PlayerStats>().SetPreviousPos(collision.gameObject.transform.position); 
            FindObjectOfType<PlayerStats>().SetPreviousHealth(); 

            //stops movement and throw temporarly
            movement.toggleMovement(); throwAxe.toggleThrow();

            //Sets start and new camera pos and starts lerping in the update
            startCameraPos = Camera.main.transform.position;
            newCameraPos = Camera.main.transform.position += CameraChange;

            startTransition = true; 
        }
    }
}
