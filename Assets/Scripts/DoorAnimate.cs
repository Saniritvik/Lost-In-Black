using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimate : MonoBehaviour
{
    public Animator animator;
    public GameObject s;
    private bool playerinRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerinRange && Input.GetButtonDown("Interact")) 
        {
            s.gameObject.SetActive(true);
            animator.SetTrigger("door");
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerinRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerinRange = false;
        }
    }
}
