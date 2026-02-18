using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TwoPoints : MonoBehaviour
{
    public UnityEvent Action;
    
    private bool PulledOne;
    
    private bool PulledTwo;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (PulledOne && PulledTwo)
        {
            Action.Invoke();
        }
    }
    public void PullOne() 
    {
        PulledOne = true;
    }
    public void PullTwo() 
    { 
        PulledTwo = true; 
    }
    public void ReturnOne()
    {
        PulledOne = false;
    }
    public void ReturnTwo()
    {
        PulledTwo = false;
    }
}
