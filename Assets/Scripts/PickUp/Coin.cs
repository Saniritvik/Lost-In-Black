using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityEvent CoinCollected;
    
    private ScoreKeeper ScoreKeeperer;
    
    private CoinCounter CoinCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreKeeperer = FindObjectOfType<ScoreKeeper>();
        CoinCounter = FindObjectOfType<CoinCounter>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PickUpCoin()
    {
        ScoreKeeperer.CoinGrab();
        CoinCounter.CollectCoin();
        Destroy(gameObject);
    }
}
