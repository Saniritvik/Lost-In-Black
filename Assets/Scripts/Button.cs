using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public Animator Animatorer;
    
    public int ButtonPressNeed;
    
    public UnityEvent ButtonPressed;
    
    private int ButtonPressAmount;
    public void PressButton() 
    {
        Animatorer.SetTrigger("Press");
        ButtonPressAmount++;
        
        if (ButtonPressAmount == ButtonPressNeed) 
        {
            ButtonPressed.Invoke();
        }
    }
}
