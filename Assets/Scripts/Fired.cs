using UnityEngine;
using UnityEngine.EventSystems;

public class Fired : MonoBehaviour
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
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }
    private void OnEnable()
    {
        
    }
}
