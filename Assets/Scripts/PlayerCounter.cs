using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCounter : MonoBehaviour
{
    public UnityEvent Action;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Action.Invoke();
        }
    }
    public void delete()
    {
        gameObject.SetActive(false);
    }

}
