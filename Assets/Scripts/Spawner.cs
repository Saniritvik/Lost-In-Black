using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] aliens;
    private GameObject[] enemies;
    private float spawnX;
    private float spawnY;
    private int amountSpawned;
    private int spawnLimit = 5;
    public int spawnMax = 5;
    public Round round;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        round = FindFirstObjectByType<Round>();

    }

    // Update is called once per frame
    void Update()
    {

            enemies = GameObject.FindGameObjectsWithTag("Alien");
        if (enemies.Length == 0 || enemies == null) 
        {
            round.roundEnd = true;
        }
    }


    public void spawn()
    {
        spawnLimit = spawnMax;
        while (spawnLimit >= 0)
        {
            Debug.Log(spawnLimit);
            int potentialEnemy = aliens.Length;
            int enemyToSpawn = Random.Range(0, potentialEnemy);
            amountSpawned = enemyToSpawn;
            if (amountSpawned == 0)
            {
                amountSpawned = 1;
            }
            if ((spawnLimit -= amountSpawned) > 0)
            {
                spawnX = Random.Range(2.5f, 14);
                spawnY = Random.Range(-7.5f, 7.5f);
                Vector2 spawnLocation = new Vector2(spawnX, spawnY);
                Instantiate(aliens[enemyToSpawn], spawnLocation, Quaternion.identity);
            }
        }
    }
}
