using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.Events;
public class DialougeAction : MonoBehaviour
{
    public UnityEvent Action;
    
    public TextMeshProUGUI textMeshPro;
    
    public string[] line;
    
    public float textspeed;
    
    private int index;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        textMeshPro.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Interact") || Input.GetButtonDown("InteractTwo"))
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
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        Action.Invoke();
    }
}
