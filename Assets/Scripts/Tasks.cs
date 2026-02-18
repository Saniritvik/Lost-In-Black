using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tasks : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool house;
    private bool search;
    private bool clueOne;
    private bool clueTwo;
    private bool clueThree;
    private bool rumor;
    private int clues;
    public GameObject[] firstDia;
    public GameObject[] secondDia;
    public string scene;
    
    // Start is called before the first frame update
    void Start()
    {
        text.text = ("Find Victor's home");
    }

    // Update is called once per frame
    void Update()
    {
        if (house)
        {
            if (clueOne && clueTwo && clueThree) 
            {
                text.text = ("Find out where Victor is going");
                foreach (GameObject go in firstDia)
                {
                    go.gameObject.SetActive(false);
                }
                foreach (GameObject goe in secondDia)
                {
                    goe.gameObject.SetActive(true);
                }
                if (rumor) 
                {
                    SceneManager.LoadScene(scene);
                }

            }
        }
    }
    public void home() 
    { 
        house = true;
        text.text = ("Enter the home");
    }
    public void Enter()
    {
        text.text = ("Find the clues 0/3");
    }
    public void searchClueOne()
    {
        if (!clueOne)
        {
            clues++;
        }
        clueOne = true;
        text.text = ("Find the clues " + clues + "/3");
    }
    public void searchClueTwo()
    {
        if (!clueTwo) 
        { 
            clues++;
        }
        clueTwo = true;
        text.text = ("Find the clues " + clues + "/3");
    }
    public void searchClueThree()
    {
        if (!clueThree)
        {
            clues++;
        }
        clueThree = true;
        text.text = ("Find the clues " + clues + "/3");
    }
    public void rumorOne()
    {
        rumor = true;

    }
}
