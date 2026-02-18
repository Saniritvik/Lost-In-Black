using UnityEngine;

public class AlienFired : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(speed, -rb.linearVelocity.y);
    }
}
