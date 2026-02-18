using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeightPuzzle : MonoBehaviour
{
    
    private int LB;
    public TextMeshProUGUI LBCounter;
    public TextMeshProUGUI LBAnswer;
    public int Answer;
    public int StartingValue;
    public UnityEvent Action;
    public GameObject Dialouge;
    public GameObject WeightPuzzleGUI;
    public GameObject UIManager;
    public GameObject Balance;
    public Sprite Starting;
    public Sprite TooHeavy;
    public Sprite TooLight;
    public Sprite Equal;
    private PlayerManager Player;
    private PuzzleManager Manager;
    private SpriteRenderer SpriteRenderer;
    private Image ImageRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Player = UIManager.GetComponent<PlayerManager>();
        ImageRenderer = Balance.GetComponent<Image>();
        Manager = UIManager.GetComponent<PuzzleManager>();
        LB = StartingValue;
        LBAnswer.text = Answer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        LBCounter.text = LB.ToString();
        if (LB > Answer) 
        {
            ImageRenderer.sprite = TooHeavy;
        }else if (LB < Answer)
        {
            ImageRenderer.sprite = TooLight;
        }
        if(LB == Answer)
        {
            ImageRenderer.sprite = Equal;
            Time.timeScale = 1;
             Manager.WeightSolved = true;
            Player.AllowMove = true;
            if (Dialouge != null)
            {
                Dialouge.SetActive(true);
            }
            else if (Action != null)
            { 
                Action.Invoke();
            }
            WeightPuzzleGUI.SetActive(false);
        }
    }
    public void AddThree()
    {
        LB += 3;
    }
    public void AddFive()
    {
        LB += 5;
    }
    public void AddSeven()
    {
        LB += 7;
    }
    public void AddEleven()
    {
        LB += 11;
    }
    public void StartOver()
    {
        LB = StartingValue;
    }
    public void Exit() 
    {
        WeightPuzzleGUI.SetActive(false);
        Player.AllowMove = true;
        Time.timeScale = 1;
    }

}
