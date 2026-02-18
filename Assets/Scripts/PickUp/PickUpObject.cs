using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpObject : MonoBehaviour
{
    public UnityEvent PickUp;
    private bool PickedUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || collision.gameObject.CompareTag("PlayerTwo") && !PickedUp)
        {
            PickUp.Invoke();    
            PickedUp = true;
        }
    }
}
