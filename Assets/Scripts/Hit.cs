using UnityEngine;

public class Hit : MonoBehaviour
{
    public Alien alien;
    public Movement movement;
    public Upgrades upgrades;
    public int pierce = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = FindFirstObjectByType<Movement>();
        upgrades = FindFirstObjectByType<Upgrades>();

    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
