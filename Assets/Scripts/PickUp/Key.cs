using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private PlayerManager playerManager;
    private bool PickUp;
    
    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickUpKey()
    {
        playerManager.KeyGrab();
        Destroy(gameObject);
    }
}
