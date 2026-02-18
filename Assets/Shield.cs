using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool shield;
    public int durabilityMax = 5;
    public int durability;
    public float regenTime = 10f;
    public float regen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        regen = regenTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(durability != durabilityMax && shield == true)
        {
            regen -= Time.deltaTime;
            if(regen < 0)
            {
                durability += 1;
                regen = regenTime;
            }
        }
    }
}
