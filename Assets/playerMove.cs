using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Movement movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = FindFirstObjectByType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void move()
    {
        if(movement.allowMove == true)
        {
            print("stop");
            movement.allowMove = false;
        }
        else
        {
            movement.allowMove = true;
        }
    }
}
