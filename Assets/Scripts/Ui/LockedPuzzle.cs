using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LockedPuzzle : MonoBehaviour
{
    public UnityEvent Action;
    
    public TextMeshProUGUI LeftLock;
    
    public TextMeshProUGUI MiddleLock;
    
    public TextMeshProUGUI RightLock;
    
    public GameObject UIManager;
    
    public int LeftAnswer;
    
    public int MiddleAnswer;
    
    public int RightAnswer;
    
    private int LeftCurrent;
    
    private int MiddleCurrent;
    
    private int RightCurrent;
    
    private bool LeftCorrect;
    
    private bool MiddleCorrect;
    
    private bool RightCorrect;
    
    private PlayerManager PlayerManagerer;
    
    // Update is called once per frame
    private void Start()
    {
        PlayerManagerer = UIManager.GetComponent<PlayerManager>();
        
        LeftLock.text = "0";
        MiddleLock.text = "0";
        RightLock.text = "0";
    }
    void Update()
    {
        LeftCorrect = LeftCurrent == LeftAnswer;
        MiddleCorrect = MiddleCurrent == MiddleAnswer;
        
        RightCorrect = RightCurrent == RightAnswer;
        LeftCorrect = LeftCorrect && RightCorrect;
        
        if (LeftCorrect && MiddleCorrect && RightCorrect)
        {
            gameObject.SetActive(false);
            Action.Invoke();

        }
    }
    public void RollLeft() 
    {
        LeftCurrent++;
        
        if (LeftCurrent > 9) 
        { 
            LeftCurrent = 0;
        }
        LeftLock.text = LeftCurrent.ToString();
    }
    public void RollMiddle()
    {
        MiddleCurrent++;
        
        if (MiddleCurrent > 9)
        {
            MiddleCurrent = 0;
        }
        MiddleLock.text = MiddleCurrent.ToString();
    }
    public void RollRight()
    {
        RightCurrent++;
        
        if (RightCurrent > 9)
        {
            RightCurrent = 0;
        }
        RightLock.text = RightCurrent.ToString();
    }
    private void OnEnable()
    {
        PlayerManagerer.AllowMove = false;
    }
}
