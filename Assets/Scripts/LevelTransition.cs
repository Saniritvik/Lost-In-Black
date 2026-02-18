using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator LevelOne;
    public Animator LevelTwo;
    public Animator LevelThree;
    public void One()
    {
        LevelOne.SetTrigger("One");
    }
    public void Two()
    {
        LevelTwo.SetTrigger("Two");
    }
    public void Three()
    {
        LevelThree.SetTrigger("Three");
    }
}
