using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
public class DialougeBoxAutomatic : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    
    public string[] line;
    
    
    public float textspeed;
    public float nextSpeed;
    private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
            if (textMeshPro.text == line[index])
            {
                StartCoroutine(NextLine());
            }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in line[index].ToCharArray())
        {
            textMeshPro.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
    IEnumerator NextLine()
    {
        if (index < line.Length - 1)
        {
            index++;
            yield return new WaitForSeconds(nextSpeed);
            textMeshPro.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
    private void OnDisable()
    {
        textMeshPro.text = string.Empty;
    }
}
