using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class OpeningShop : MonoBehaviour
{
    public GameObject menu;
    public GameObject scrapNeeded;

    public AudioSource audioSource;

    public GameObject OPAnimation;
    public GameObject CloseAnimation;

    public UnityEngine.UI.Image Health;
    public TextMeshProUGUI Scrap;
    public TextMeshProUGUI HealthAmount;


    public float OpDelay;
    public float CloseDelay;

    private bool menuOn;
    private bool isAnimating;

    public float health_opacity = 0.5f;
    public float text_opacity = 1.0f;  

    // Start is called before the first frame update
    private void Start()
    {
        menuOn = false;
        isAnimating = false;
    }
    private void Update()
    {

    }

    public void openMenu() {
        StartCoroutine(menuAndAnimation());
    }

    public void resume()
    {
        StartCoroutine(closeThenHide());
    }
    IEnumerator menuAndAnimation()
    {
        isAnimating = true;

        OPAnimation.SetActive(true);

        yield return new WaitForSecondsRealtime(OpDelay);

        OPAnimation.SetActive(false);
        menu.SetActive(true);
        menuOn = true;

        Color currentHealthColor = Health.color;

        currentHealthColor.a = health_opacity;

        Health.color = currentHealthColor;

        Color currentScrapColor = Scrap.color;

        currentScrapColor.a = text_opacity;

        Scrap.color = currentScrapColor;

        Color currentHealthTextColor = HealthAmount.color;

        currentHealthTextColor.a = text_opacity;

        HealthAmount.color = currentHealthTextColor;

        if (audioSource != null) audioSource.Pause();

        isAnimating = false;

    }

    IEnumerator closeThenHide()
    {
        Color currentHealthColor = Health.color;

        currentHealthColor.a = 0;

        Health.color = currentHealthColor;

        Color currentScrapColor = Scrap.color;

        currentScrapColor.a = 0;

        Scrap.color = currentScrapColor;

        Color currentHealthTextColor = HealthAmount.color;

        currentHealthTextColor.a = 0;

        HealthAmount.color = currentHealthTextColor;

        isAnimating = true;

        menu.SetActive(false);

        scrapNeeded.SetActive(false);

        CloseAnimation.SetActive(true);
        yield return new WaitForSecondsRealtime(CloseDelay);
        CloseAnimation.SetActive(false);

        menuOn = false;
        if (audioSource != null) audioSource.Play();

        isAnimating = false;
    }
}
