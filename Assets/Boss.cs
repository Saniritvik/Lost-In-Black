using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Boss : MonoBehaviour
{
    public float healthPoint = 100;
    public Movement movement;
    public Hit hit;
    public int lazer;
    public float lazerDelay = 1f;
    public GameObject horAttack;
    public GameObject verAttack;
    private GameObject ship;
    public Animator animator;
    public Animator lazeranimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = FindFirstObjectByType<Movement>();
        ship = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            healthPoint -= movement.damage;
            hit = collision.GetComponent<Hit>();
            hit.pierce -= 1;
            if ((healthPoint <= 0))
            {
                Destroy(gameObject);
            }
        }
    }
    private IEnumerator HoriAttack()
    {
        lazer = Random.Range(1, 4);
        for (int i = 0; i < lazer; i++)
        {
            var shipY = ship.transform.position.y;
            Vector2 hor = new Vector2(13, shipY);

            Instantiate(horAttack, hor, Quaternion.identity);
            if (lazer == 1)
            {
                animator.SetInteger("Sweep", 1);
            }
            else
            {
                yield return new WaitForSeconds(lazerDelay);
            }

        }
    }
    public void HorAttack()
    {
        StartCoroutine(HoriAttack());
    }
    private IEnumerator VertAttack()
    {
        var lazer = Random.Range(1, 3);
        for (int i = 0; i < lazer; i++)
        {
            var shipX = ship.transform.position.x;
            Vector2 ver = new Vector2(shipX, 19);

            Instantiate(verAttack, ver, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(lazerDelay);
        }
    }
    public void VerAttack()
    {
        StartCoroutine(VertAttack());
    }
    public void PerpadenAttack()
    {
        var lazer = Random.Range(2, 3);
        for (int i = 0; i < lazer; i++)
        {
            var x = Random.Range(-15, -3);
            Vector2 ver = new Vector2(x, 19);
            Instantiate(verAttack, ver, Quaternion.Euler(0f,0f,90f));
            var y = Random.Range(-7, 7);
            Vector2 hor = new Vector2(13, y);

            Instantiate(horAttack, hor, Quaternion.identity);
        }
    }
    public void randomAttack()
    {
        var attack = Random.Range(-1, 2);
        animator.SetInteger("Attacks",attack);
    }
}
