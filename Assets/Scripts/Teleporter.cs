using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool OneTime;
    public Transform ExitPoint;
    private Vector3 Exit;
    // Start is called before the first frame update
    public void Start()
    {
        Exit = ExitPoint.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || (collision.gameObject.CompareTag("PlayerTwo")))
        {
            collision.transform.position = Exit;
            if(OneTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
