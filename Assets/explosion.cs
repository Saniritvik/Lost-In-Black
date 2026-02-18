using UnityEngine;

public class explosion : MonoBehaviour
{
    private float scale = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scale <= 0.1)
        {
            Destroy(gameObject);
        }
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
        scale -= Time.deltaTime;
    }
}
