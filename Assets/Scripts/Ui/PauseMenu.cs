using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goMainMenu : MonoBehaviour
{
    public GameObject menu;
    
    public AudioSource audioSource;

    public GameObject OPAnimation;
    public GameObject CloseAnimation;

    public GameObject Health;
    public GameObject Charge;
    public GameObject Pro;
    public GameObject Scrap;
    public GameObject advanceButton;
    public GameObject advanceDropDown;


    public float OpDelay;
    public float CloseDelay;

    private bool menuOn;
    private bool isAnimating;

    // Start is called before the first frame update
    private void Start()
    {
        menuOn = false;
        isAnimating = false;
    }
    private void Update()
    {

        if (Input.GetButtonDown("Pause") && !isAnimating)
        {
            if (!menuOn)
            {
                StartCoroutine(menuAndAnimation());
            }
            else if(menuOn)
            {
                StartCoroutine(closeThenHide());
            }
        }
    }
    public void mainMenu()
    {
        SceneManager.LoadSceneAsync("Main menu");
        menu.SetActive(false);
        
        Time.timeScale = 1;
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
    public void resume()
    {
        StartCoroutine(closeThenHide());
    }
    IEnumerator menuAndAnimation() { 
        Health.SetActive(false);
        Pro.SetActive(false);  
        Charge.SetActive(false);
        Scrap.SetActive(false);
        
        isAnimating = true;

        OPAnimation.SetActive(true);

        yield return new WaitForSecondsRealtime(OpDelay);

        advanceButton.SetActive(true);
        OPAnimation.SetActive(false);
        menu.SetActive(true);
        menuOn = true;
        Time.timeScale = 0;
        
        if (audioSource != null) audioSource.Pause();

        isAnimating = false;

    }

    IEnumerator closeThenHide() {
        isAnimating = true;

        Time.timeScale = 1;

        menu.SetActive(false);

        advanceButton.SetActive(false);
        advanceDropDown.SetActive(false);

        CloseAnimation.SetActive(true);
        yield return new WaitForSecondsRealtime(CloseDelay);
        CloseAnimation.SetActive(false);

        menuOn = false;
        if (audioSource != null) audioSource.Play();

        isAnimating = false;

        Health.SetActive(true);
        Pro.SetActive(true);
        Charge.SetActive(true);
        Scrap.SetActive(true);
    }
}


