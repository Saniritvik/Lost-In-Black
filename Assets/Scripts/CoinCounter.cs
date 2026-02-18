using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public GameObject Banner;
    public int CollectNeeded;
    private int CollectedCoins;
    private bool Activated;
    public void CollectCoin()
    {
        CollectedCoins++;
        if (CollectedCoins >= CollectNeeded && !Activated) 
        {
            Banner.SetActive(true);
        }
    }
}
