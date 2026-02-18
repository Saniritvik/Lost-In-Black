using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using static Unity.Collections.Unicode;

public class Round : MonoBehaviour
{
    public TextMeshProUGUI roundCounter;
    public Animator roundAnimate;
    public string roundWord;
    public bool roundTrigger = true;
    public float timer = 10;
    public int waves = 5;
    private int wavesRemaining;
    public int waveCount;
    private float intermission;
    public bool roundEnd;
    public bool shopping;
    public Spawner spawner;
    public string[] boss;
    public int bossRound;
    public int bossCount;
    public PlayableDirector toShop;
    public PlayableDirector toBattle;
    public Movement movement;
    public Alien[] alien;
    public AudioSource waveEnd;
    public string scrapDeleter = "Scrap";
    public Shop shop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = FindFirstObjectByType<Spawner>();
        intermission = timer;
        wavesRemaining = waves;
    }

    // Update is called once per frame
    void Update()
    {
        Alien[] alien = Object.FindObjectsByType<Alien>(FindObjectsSortMode.None);
        foreach (Alien obj in alien)
        {
            obj.firingChance = Mathf.RoundToInt(3 + 11/10*(waveCount ^  11/10));
        }
        if (waveCount % bossRound == 0)
        {
            SceneManager.LoadSceneAsync(boss[bossCount]);
            waveCount++;
        }
        else if (roundEnd && wavesRemaining > 0 && !shopping)
        {
            intermission -= Time.deltaTime;
        }
        else if (roundEnd && wavesRemaining <= 0 ) 
        {
            wavesRemaining = waves;
            shopping = true;
            movement.allowMove = false;

            GameObject[] scrapToDelete = GameObject.FindGameObjectsWithTag(scrapDeleter);

            foreach (GameObject i in scrapToDelete)
            {
                shop.scraps += 10;
                Destroy(i);
            }

            toShop.Play();

        }
        if (intermission < 3 && intermission > 2.9 && roundTrigger)
        {
            roundCounter.text = roundWord + " " + waveCount.ToString();
            roundAnimate.SetTrigger("Round");
            waveEnd.Play();
            roundTrigger = false;
        }
        if (intermission <= 0)
        {
            roundTrigger = true;
            roundEnd = false;
            wavesRemaining -= 1;
            intermission = timer;
            spawner.spawn();
            spawner.spawnMax += 2;
            waveCount++;
        }
    }
    private void FixedUpdate()
    {
        
    }
    public void nextRound()
    {
        toBattle.Play();
        roundEnd = false;
        shopping = false;
        spawner.spawnMax += 2;
    }
}
