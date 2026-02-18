using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform ExitDoor;
    
    private Vector3 Exit;

    private GameObject player;

    private bool playerInRange;
    
    // Start is called before the first frame update
    void Start()
    {
        Exit = ExitDoor.position;
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            player.transform.position = Exit;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player) 
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (player)
        {
            playerInRange = false;
        }
    }
}
