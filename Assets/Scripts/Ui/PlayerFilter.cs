using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFilter : MonoBehaviour
{
    public GameObject player;
    
    public GameObject playerOne;
    
    public GameObject playerTwo;
    
    public KeyCode playerOneButton;
    
    public KeyCode playerTwoButton;
    public GameObject InteractFilter()
    {
        if (Input.GetKeyDown(playerOneButton) && player == playerOne)
        {
            return playerOne;
        }
        else if (Input.GetKeyDown(playerTwoButton) && player == playerTwo)
        {
            return playerTwo;
        }
        else
        {
            return null;
        }

     }
}
