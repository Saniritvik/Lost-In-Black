using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Interact : MonoBehaviour
{
    private bool InRangePlayerOne;

    public GameObject E;
    public UnityEvent PlayerOneAction;
   
    
    public Animator Animation;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (InRangePlayerOne && Input.GetButtonDown("Interact"))
        {
            PlayerOneAction.Invoke();
            
            if (Animation != null)
            {
                Animation.SetBool("e", true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            E.gameObject.SetActive(true);
            InRangePlayerOne = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            E.gameObject.SetActive(false);
            InRangePlayerOne = false;
        }
    }
}
