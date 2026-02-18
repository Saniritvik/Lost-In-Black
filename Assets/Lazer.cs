using UnityEngine;

public class Lazer : MonoBehaviour
{
    private Boss boss;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        animator = GetComponent<Animator>();
        boss = FindFirstObjectByType<Boss>();
        if (boss.lazer == 1)
        {
            animator.SetInteger("Sweep", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
