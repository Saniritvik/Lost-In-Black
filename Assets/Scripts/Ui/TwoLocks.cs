using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TwoLocks : MonoBehaviour
{
    
    public GameObject UIManager;
    
    public UnityEvent Action;
    
    private bool UnlockedOne;
    
    private bool UnlockedTwo;
    
    private bool Activated;
    
    private PlayerManager PlayerManagerer;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerManagerer = UIManager.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnlockedOne && UnlockedTwo && !Activated)
        { 
            Action.Invoke();
            Activated = true;
        }
    }
    public void KeyUsedOne() 
    {
        if(PlayerManagerer.KeyCount > 0 && !UnlockedOne)
        {
            UnlockedOne = true;
            PlayerManagerer.KeyUse();
        }
    }
    public void KeyUsedTwo()
    {
        if (PlayerManagerer.KeyCount > 0 && !UnlockedTwo)
        {
            UnlockedTwo = true;
            PlayerManagerer.KeyUse();
        }
    }
}
