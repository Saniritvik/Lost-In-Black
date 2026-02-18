using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private PlayerManager playerManager;
    
    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PickUpSquare()
    {
        playerManager.SquareGrab();
        Destroy(gameObject);
    }
}
