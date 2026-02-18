using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockPickUp : MonoBehaviour
{
    public float ThrowForce;
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    private Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void pickUpPlayerOne()
    {
        if (HasParent(gameObject))
        {
            gameObject.transform.parent = null;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(rb.linearVelocity.x, 1000));
        }
        else
        {
            gameObject.transform.parent = PlayerOne.transform;
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.position = new Vector3(1, 1, 0);
        }
    }
    public void pickUpPlayerTwo()
    {
        if (HasParent(gameObject))
        {
            gameObject.transform.parent = null;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(ThrowForce, 0));

        }
        else
        {
            gameObject.transform.parent = PlayerTwo.transform;
            rb.bodyType = RigidbodyType2D.Kinematic;

        }
    }
    bool HasParent(GameObject child)
    {
        return child.transform.parent != null;

    }
}
