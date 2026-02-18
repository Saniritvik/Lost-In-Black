using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Transform Open;
    public Transform Close;
    public float Speed = 2f;
    public bool AllowedOpen;
    private Vector3 next;
    // Start is called before the first frame update
    void Start()
    {
        next = Open.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowedOpen)
        {
            if (transform.position != next)
            {
                transform.position = Vector3.MoveTowards(transform.position, next, Speed * Time.deltaTime);
            }
        }
    }
    public void OpenGate() 
    {
        AllowedOpen = true;
        if (next != Open.position) 
        {
            next = Open.position;
        }
    }

    public void CloseGate()
    {
        next = Close.position;
    }
}
