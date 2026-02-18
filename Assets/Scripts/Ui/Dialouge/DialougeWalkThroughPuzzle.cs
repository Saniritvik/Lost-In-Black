using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialougeWalkThroughPuzzle : MonoBehaviour
{
    public GameObject UIManager;
    
    public GameObject Dialouge;
    
    private PuzzleManager PuzzleManagerer;
    
    private PlayerManager PlayerManagerer;
    
    private bool Triggered;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerManagerer = UIManager.GetComponent<PlayerManager>();
        PuzzleManagerer = UIManager.GetComponent<PuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PuzzleManagerer.WeightSolved)
        {
            if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
            {
                Dialouge.SetActive(true);
                PlayerManagerer.AllowMove = false;
            }

        }
    }
}
