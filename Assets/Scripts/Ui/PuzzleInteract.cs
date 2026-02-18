using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleInteract : MonoBehaviour
{
    private bool InRangePlayerOne;
    
    private bool InRangePlayerTwo;
    
    public GameObject Puzzle;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        { 
            Puzzle.SetActive(false);
        }
        
        if (InRangePlayerOne && Input.GetButtonDown("Interact"))
        {
            Puzzle.SetActive(true);
            Time.timeScale = 0;
        }
        else if (InRangePlayerTwo && Input.GetButtonDown("InteractTwo"))
        {
            Puzzle.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            InRangePlayerOne = true;
        }
        else if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            InRangePlayerTwo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            InRangePlayerOne = false;
        }
        else if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            InRangePlayerTwo = false;
        }
    }
}
