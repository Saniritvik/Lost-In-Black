using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddler : MonoBehaviour
{
    public GameObject FirstTime;
    public GameObject ReadTheBook;
    public GameObject Quiz;
    private bool ReadBook;
    private bool Talked;
    public void RiddlerInteract()
    {
        if (Talked)
        {
            if (ReadBook)
            {
                if (!Quiz.activeInHierarchy) { Quiz.SetActive(true); }
            }
            else 
            {
                if (!ReadTheBook.activeInHierarchy) { ReadTheBook.SetActive(true); }
            }
        }
        else 
        {
            if (!FirstTime.activeInHierarchy) { FirstTime.SetActive(true); }
            Talked = true;
        }
    }
    public void Read() 
    {
        ReadBook = true;
    }
}
