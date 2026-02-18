using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject UIManager;
    private Respawn Respawner;
    // Start is called before the first frame update
    void Start()
    {
        Respawner = UIManager.GetComponent<Respawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            collision.gameObject.transform.position = Respawner.RespawnerOne;
        }
        else if(collision.gameObject.CompareTag("PlayerTwo"))
        {
            collision.gameObject.transform.position = Respawner.RespawnerTwo;
        }
    }
}
