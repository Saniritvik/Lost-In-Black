using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using System.Collections.Generic;
using TMPro;
using System.Transactions;
public class cycle : MonoBehaviour
{
    public TextMeshProUGUI projectileTracker;
    public Movement movement;
    public Shop shop;
    public List<Weopons> weapons;
    public List<Weopons> availableWeopons;
    public Hit hit;
    public int index;
    public int currentIndex;
    public RuntimeAnimatorController RailAnimation;
    public RuntimeAnimatorController PrimaryAnimation;
    public RuntimeAnimatorController BurstAnimation;
    public RuntimeAnimatorController BlackAnimation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = FindFirstObjectByType<Movement>();
        shop = FindFirstObjectByType<Shop>();
        hit = FindFirstObjectByType<Hit>();
        movement.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            index = ((index + 1) % availableWeopons.Count);
            if (index > availableWeopons.Count - 1) 
            {
                index = 0;
            }
            currentIndex = Mathf.Abs(index);
            movement.fireRate = availableWeopons[index].firing;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            index = ((index - 1) % availableWeopons.Count);
            if (index < 0)
            {
                index = availableWeopons.Count-1;
            }
            currentIndex = Mathf.Abs(index);
            movement.fireRate = availableWeopons[currentIndex].firing;
        }

        movement.projectile = availableWeopons[currentIndex].weopon;
        projectileTracker.text = availableWeopons[currentIndex].name;

        if (availableWeopons[currentIndex].name == "Piercer") {
            movement.animator.runtimeAnimatorController = RailAnimation;
            movement.damage = availableWeopons[currentIndex].damage + shop.pierceDamageUp;
            movement.fireSpeed = availableWeopons[currentIndex].firing;
        }
        
        if (availableWeopons[currentIndex].name == "Slinger")
        {
            movement.animator.runtimeAnimatorController = PrimaryAnimation;
            movement.damage = availableWeopons[currentIndex].damage + shop.slingerDamageUp;
            movement.fireSpeed = availableWeopons[currentIndex].firing;
        }

        if (availableWeopons[currentIndex].name == "Burst")
        {
            movement.animator.runtimeAnimatorController = BurstAnimation;
            movement.damage = availableWeopons[currentIndex].damage * shop.burstDamageUp;
            movement.fireSpeed = availableWeopons[currentIndex].firing + shop.burstFireRateUp;
        }

        if (availableWeopons[currentIndex].name == "BlackHole")
        {
            movement.animator.runtimeAnimatorController = BlackAnimation;
            movement.damage = availableWeopons[currentIndex].damage;
            movement.fireSpeed = availableWeopons[currentIndex].firing + shop.bFireRateUp;
        }

    }
}
