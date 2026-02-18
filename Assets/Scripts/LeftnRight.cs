using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftnRight : MonoBehaviour
{
    public AudioSource music;
    private float pan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        music.panStereo = pan;
        if (pan == 0)
        {
            while (pan <= 1)
            {
                pan += (float)0.01;
            }
        }
        else if (pan >= 1)
        {
            while (pan >= -1)
            {

                pan -= (float)0.01;
            }
        }
        else if (pan <= -1)
        {
            while (pan <= 1)
            {
                pan += (float)0.01;
            }
        }

        
    }
}
