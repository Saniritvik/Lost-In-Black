using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObject : MonoBehaviour
{
    public GameObject Object;
    private bool enable = false;
    public void ObjectOpen() 
    {
        enable = !enable; 
        Object.SetActive(enable);
    }

}
