using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatorom : MonoBehaviour
{   
    public GameObject platform;
    
    private bool isPulled;
    
    public Animator animator;
    
    public void Pull()
    {
        if (!isPulled) 
        {
            isPulled = true;
            Vector2 platforms = new Vector2((float)23.5, (float)8.5);
            
            Instantiate(platform, platforms, Quaternion.identity);
            
            if (animator != null)
            {
                animator.SetBool("e", true);
            }
        }
    }

}
