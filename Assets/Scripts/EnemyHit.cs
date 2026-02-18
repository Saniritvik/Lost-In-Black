using UnityEngine;
using UnityEngine.Events;

public class EnemyHit : MonoBehaviour
{
    public int damage = 10;
    public Movement movement;
    public Shield shield;
    public int pierce = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = FindFirstObjectByType<Movement>();
        shield = FindFirstObjectByType<Shield>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (shield.shield == true) 
            {
                if (!movement.iFrame)
                {
                    movement.healthPoint -= damage / 2;
                    if (shield.durability > 0)
                    {
                        shield.durability -= 1;
                    }
                    shield.regen = shield.regenTime;
                    pierce -= 1;
                }
            }
            else
            {
                if (!movement.iFrame)
                {
                    movement.healthPoint -= damage;
                    pierce -= 1;
                }
            }
        }
        if (pierce <= 0)
        {
            Destroy(gameObject);
        }

    }
}
