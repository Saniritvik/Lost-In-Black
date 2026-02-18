using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedMove : MonoBehaviour
{
    public int UpTime;
    public int DownTime;
    public float Speed;
    public bool StartUp;
    public Transform Up;
    public Transform Down;
    private Vector3 Next;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        if (StartUp)
        {
            Next = Down.position;
        }
        else
        {
            Next = Up.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Next == Up.position)
        {
            if (Timer >= UpTime)
            {
                Next = Down.position;
                Timer = 0;
            }
        } 
        else if (Next == Down.position)
            {
            if (Timer >= DownTime)
                {
                    Next = Up.position;
                    Timer = 0;
                }
            }
        transform.position = Vector3.MoveTowards(transform.position, Next, Speed * Time.deltaTime);
    }
}
