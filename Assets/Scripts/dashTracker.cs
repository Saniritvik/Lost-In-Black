using System.Runtime.CompilerServices;
using UnityEngine;

public class dashTracker : MonoBehaviour
{
    private float dashTimer = 1;
    public float dashRate = 2;
    public float dashAmount = 20;
    public DaskDirection E;
    public DaskDirection N;
    public DaskDirection S;
    public DaskDirection W;
    public DaskDirection NE;
    public DaskDirection NW;
    public DaskDirection SW;
    public DaskDirection SE;
    public GameObject ship;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float iFrameLength;
    private float iFrameTime;
      

        // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Movement movement;
    void Start()
    {
        movement = FindFirstObjectByType<Movement>();

    }

    // Update is called once per frame
    void Update() 
    {
        dashTimer -= Time.deltaTime;
        Vector2 ELocation = new Vector2(
            Mathf.Clamp(ship.transform.position.x + dashAmount, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
        );
        E.transform.position = ELocation;

        Vector2 NLocation = new Vector2(
            Mathf.Clamp(ship.transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y + dashAmount, minY, maxY)
        );
        N.transform.position = NLocation;

        Vector2 WLocation = new Vector2(
            Mathf.Clamp(ship.transform.position.x - dashAmount, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
        );
        W.transform.position = WLocation;

        Vector2 SLocation = new Vector2(
            Mathf.Clamp(ship.transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y - dashAmount, minY, maxY)
        );
        S.transform.position = SLocation;

        Vector2 NELocation = new Vector2(
            Mathf.Clamp(ship.transform.position.x + dashAmount, minX, maxX),
            Mathf.Clamp(transform.position.y + dashAmount, minY, maxY)
        );
        NE.transform.position = NELocation;

        Vector2 NWLocation = new Vector2(
            Mathf.Clamp(ship.transform.position.x - dashAmount, minX, maxX),
            Mathf.Clamp(transform.position.y + dashAmount, minY, maxY)
        );
        NW.transform.position = NWLocation;

        Vector2 SWLocation = new Vector2(
            Mathf.Clamp(ship.transform.position.x - dashAmount, minX, maxX),
            Mathf.Clamp(transform.position.y - dashAmount, minY, maxY)
        );
        SW.transform.position = SWLocation;

        Vector2 SELocation = new Vector2(
            Mathf.Clamp(ship.transform.position.x + dashAmount, minX, maxX),
            Mathf.Clamp(transform.position.y - dashAmount, minY, maxY)
        );
        SE.transform.position = SELocation;
        if (Input.GetButtonDown("Dash") && dashTimer <= 0)
        {
            if (movement.moveDirection.x > 0.5f && movement.moveDirection.y > 0.5f && NE.clear)
            {
                ship.transform.position = NELocation;
                dashTimer = dashRate;
            }
            else if (movement.moveDirection.x < -0.5f && movement.moveDirection.y > 0.5f && NW.clear)
            {
                ship.transform.position = NWLocation;
                dashTimer = dashRate;
            }
            else if (movement.moveDirection.x < -0.5f && movement.moveDirection.y < -0.5f && SW.clear)
            {
                ship.transform.position = SWLocation;
                dashTimer = dashRate;
            }
            else if (movement.moveDirection.x > 0.5f && movement.moveDirection.y < -0.5f && SE.clear)
            {
                ship.transform.position = SELocation;
                dashTimer = dashRate;
            }
            else if (movement.moveDirection.y > 0.5f && N.clear)
            {
                ship.transform.position = NLocation;
                dashTimer = dashRate;
            }
            else if (movement.moveDirection.y < -0.5f && S.clear)
            {
                ship.transform.position = SLocation;
                dashTimer = dashRate;
            }
            else if (movement.moveDirection.x > 0.5f && E.clear)
            {
                ship.transform.position = ELocation;
                dashTimer = dashRate;
            }
            else if (movement.moveDirection.x < -0.5f && W.clear)
            {
                ship.transform.position = WLocation;
                dashTimer = dashRate;
            }
            movement.iFrame = true;
        }
        if(movement.iFrame == true)
        {
            iFrameTime -= Time.deltaTime;
        }
        if(iFrameTime <= 0)
        {
            movement.iFrame = false;
            iFrameTime = iFrameLength;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("dashLimit")) 
        {
            movement.allowDash = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("dashLimit"))
        {
            movement.allowDash = false;        }
    }
}
