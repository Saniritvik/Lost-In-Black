using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{   
    public Transform flag;
    
    public UnityEvent checkpointBoth;

    public UnityEvent checkpointOne;

    public UnityEvent checkpointTwo;
    public bool both;
    
    private Respawn position;
    
    public Vector3 respawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        position = FindObjectOfType<Respawn>();
        respawnPoint = flag.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || collision.gameObject.CompareTag("PlayerTwo"))
        {
            position.CheckPoint = respawnPoint;
            if (both)
            {
                checkpointBoth.Invoke();
            }
            else
            {
                if (collision.gameObject.CompareTag("PlayerOne"))
                {
                    checkpointOne.Invoke();
                }else if (collision.gameObject.CompareTag("PlayerTwo"))
                {
                    checkpointTwo.Invoke();
                }

            }
        }
    }
}
