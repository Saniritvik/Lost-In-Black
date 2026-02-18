using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeWalkThrough : MonoBehaviour
{
    public GameObject Dialouge;
    
    private bool Triggered;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered)
        {
            if (collision.gameObject.CompareTag("PlayerOne"))
            {
                Dialouge.SetActive(true);
            }
            else if (collision.gameObject.CompareTag("PlayerTwo"))
            {
                Dialouge.SetActive(true);
            }
        }
    }
}
