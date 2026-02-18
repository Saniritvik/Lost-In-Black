using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public int PlayerCount;
    public UnityEvent Pressed;
    public UnityEvent NotPressed;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            PlayerCount++;
            if(PlayerCount >= 1)
            {
                Pressed.Invoke();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            PlayerCount--;
            if(PlayerCount <= 0)
            {
                NotPressed.Invoke();
            }
        }
    }
}
