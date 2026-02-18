using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ActivateOneAnimation : MonoBehaviour
{
    public Animator[] Animatorer;
    public void ActiveAnimation() 
    {
        foreach (Animator anim in Animatorer)
        {
            anim.SetBool("e", true);
        }
    }
}
