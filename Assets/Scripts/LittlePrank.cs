using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LittlePrank : MonoBehaviour
{
    public UnityEvent SizeCameraEnter;
    public UnityEvent SizeCameraExit;
    public AudioClip Spooky;
    public AudioClip Normal;
    public AudioSource Sound;
    private int PlayerCount;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            PlayerCount++;
            if (PlayerCount >= 1) 
            {
                PrankEnter();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            PlayerCount--;
            if (PlayerCount <= 0)
            {
                PrankLeave();
            }
        }
    }
    private void PrankEnter() 
    {
        Sound.clip = Spooky;
        Sound.Play();
        SizeCameraEnter.Invoke();
    }
    private void PrankLeave() 
    {
        Sound.clip = Normal;
        Sound.Play();
        SizeCameraExit.Invoke();
    }
}
