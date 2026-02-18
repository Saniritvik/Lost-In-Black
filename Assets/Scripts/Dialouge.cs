using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Composites;
using Unity.VisualScripting;

public class Dialouge : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;

    public string[] line;

    public float textspeed;

    private int index;
    public Round1 round;
    public GameObject shop;
    public GameObject actualShop;
    public UnityEngine.UI.Button shopButton;
    public UnityEngine.UI.Button buyButton1;
    public UnityEngine.UI.Button buyButton2;
    public UnityEngine.UI.Button buyButton3;
    public UnityEngine.UI.Button buyButton4;
    public UnityEngine.UI.Button buyButton5;
    public UnityEngine.UI.Button buyButton6;
    public UnityEngine.UI.Button buyButton7;
    public UnityEngine.UI.Button buyButton8;
    public UnityEngine.UI.Button backButton;

    private Scene currentScene;

    // Start is called before the first frame update
    private void OnEnable()
    {
        textMeshPro.text = string.Empty;
        StartDialogue();
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            string sceneName = currentScene.name;
            gameObject.SetActive(false);
            round.intermission = 5.00f;

            if (sceneName == "Tutorial" && shop.activeInHierarchy)
            {
                shopButton.interactable = true;
            }

            if (sceneName == "Tutorial" && actualShop.activeInHierarchy)
            {
                buyButton1.interactable = true;
                buyButton2.interactable = true;
                buyButton3.interactable = true;
                buyButton4.interactable = true;
                buyButton5.interactable = true;
                buyButton6.interactable = true;
                buyButton7.interactable = true;
                buyButton8.interactable = true;
                backButton.interactable = true;
            }
        }
    }
}
