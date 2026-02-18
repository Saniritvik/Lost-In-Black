using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public GameObject FoundStrangerDialouge;
    public GameObject CherryBanner;
    public GameObject FindDialogue;
    public GameObject FoundDialogue;
    public bool Triggered;
    private bool CherryFound;

    public void CherryStory() 
    {if (!FoundStrangerDialouge.activeSelf)
        {
            if (Triggered)
            {
                if (CherryFound)
                {
                    FoundDialogue.SetActive(true);
                    CherryBanner.SetActive(true);
                }
                else
                {
                    FindDialogue.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered)
        {
            if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
            {
                FoundStrangerDialouge.SetActive(true);
                Triggered = true;
            }
        }
    }
    public void FoundCherry() 
    {
        CherryFound = true;
    }

}
