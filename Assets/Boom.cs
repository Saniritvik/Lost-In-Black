using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject boom;
    public float boomTime = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Update()
    {
        boomTime-= Time.deltaTime;
        if (boomTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        Vector2 curLocation = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        Instantiate(boom, curLocation, Quaternion.identity);
    }
}
