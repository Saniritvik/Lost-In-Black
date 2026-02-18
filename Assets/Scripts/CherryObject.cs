using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CherryObject : MonoBehaviour
{
    public UnityEvent FindCherry;
    public GameObject CherryDialougeInteracted;
    public GameObject CherryDialougeNotInteracted;
    private Cherry Cherryer;
    // Start is called before the first frame update
    void Start()
    {
        Cherryer = FindObjectOfType<Cherry>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            if (Cherryer.Triggered)
            {
                CherryDialougeInteracted.SetActive(true);
            }
            else
            {
                CherryDialougeNotInteracted.SetActive(true);
            }
            FindCherry.Invoke();
            Destroy(gameObject);
        }
    }

}
