using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System;
public class DialougeBox : MonoBehaviour
{
    
    public TextMeshProUGUI textMeshPro;
    
    public string[] line;
    
    public float textspeed;
    
    private int index;
    private Movement allowMove;
    private bool on;
    private bool start;
    public GameObject spaceBar;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        allowMove = FindObjectOfType<Movement>();
    }
    void Update()
    {
        if (on && !start)
        {
            textMeshPro.text = string.Empty;
            StartDialogue();
            start = true;
           allowMove.allowMove = false;
            spaceBar.SetActive(true);
        }
        if (((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Box")) && start))
        {

            if (textMeshPro.text == line[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textMeshPro.text = line[index];
            }
        }    
    }
    public void startbox() 
    {
        on = true;
    }   
    
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    
    IEnumerator TypeLine() 
    {
        foreach(char c in line[index].ToCharArray())
            { 
                textMeshPro.text += c;
                yield return new WaitForSeconds(textspeed);
            }
    }
    
    void NextLine()
    {
        if (index < line.Length - 1)
        {
            index++;
            textMeshPro.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textMeshPro.text = string.Empty;
            on = false;
            start = false;
            allowMove.allowMove = true;
            spaceBar.SetActive(false);
        }
    }
}
