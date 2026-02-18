using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform A;
    
    public Transform B;
    
    public float Speed = 2f;
    
    public bool AllowedToMove;
    
    public bool SetToPressurePlate;
    
    private Vector3 next;
    
    // Start is called before the first frame update
    void Start() 
    {
        if (!SetToPressurePlate)
        {
            next = B.position;
        }
        else if(SetToPressurePlate)
        {
           next = A.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowedToMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, next, Speed * Time.deltaTime);
            
            if (transform.position == next)
            {
                next = (next == A.position) ? B.position : A.position;
            }
        }
        
        if (SetToPressurePlate) 
        {
            if (transform.position != next)
            {
                transform.position = Vector3.MoveTowards(transform.position, next, Speed * Time.deltaTime);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo"))) 
        {
            collision.gameObject.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            collision.gameObject.transform.parent = null;
        }
    }
    public void AllowMove() 
    { 
        AllowedToMove = true;
    }
    public void MovePlatformUp()
    {
        next = B.position;
    }
    public void MovePlatformDown()
    {
        next = A.position;
    }

}
