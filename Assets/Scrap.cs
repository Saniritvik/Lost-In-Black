using UnityEngine;
using UnityEngine.Events;

public class Scrap : MonoBehaviour
{
    public Shop shop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shop = FindFirstObjectByType<Shop>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            shop.collectScrap();
            Destroy(gameObject);

        }
    }
}
