using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Alien : MonoBehaviour
{
    public GameObject projectile;
    public float healthPoint = 100;
    public float movementSpeed = 3;
    public float firingSpeed = 0.1f;
    private float firingTimer;
    private float movementTimer;
    public Transform A;
    public float Speed = 2f;
    public Transform B;
    private Vector3 next;
    public Movement movement;
    public GameObject scrap;
    public Hit hit;
    private int fire = 0;
    public int firingChance = 3;
    private float hitDelay = 0;
    public float hitDelayed = 0f;
    private int chance = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = FindFirstObjectByType<Movement>();
        if (B != null)
        {
            next = B.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 alien = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if ((healthPoint <=0))
        {
            Destroy(gameObject.transform.parent.gameObject);
            
            Instantiate(scrap, alien, Quaternion.identity);
        }
        firingTimer -= Time.deltaTime;
        movementTimer -= Time.deltaTime;
        if( firingTimer <= 0 )
        {
            fire = Random.Range(1, 20);
            if (fire <= firingChance)
            {
                if (projectile != null)
                {
                    Instantiate(projectile, alien, Quaternion.identity);
                    firingTimer = firingSpeed;
                    fire = 0;
                }
            }
            firingTimer = firingSpeed;
        }
        if (A != null && B != null)
        {
            if (movementTimer <= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, next, Speed * Time.deltaTime);

                if (transform.position == next)
                {
                    next = (next == A.position) ? B.position : A.position;
                    movementTimer = movementSpeed;
                }
            }
        }
        hitDelay -= Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
                healthPoint -= movement.damage;
                hit = collision.GetComponent<Hit>();
                hit.pierce -= 1;
        }
    }

}
