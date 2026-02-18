using UnityEngine;

public class aniblast : MonoBehaviour
{
    public float charge = 0;
    public float charger = 0.01f;
    public GameObject aniBlast; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (charge <= 100)
        {
            charge += charger;

        }
        if (Input.GetButtonDown("") && charge >= 100)
        {
            Instantiate(aniBlast);
        }
    }

}
