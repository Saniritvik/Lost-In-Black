using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    public TextMeshProUGUI ScoreGUI;
    private int Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreGUI.text = Score.ToString();
    }
    public void CoinGrab()
    {
        Score += 100;
    }
}
