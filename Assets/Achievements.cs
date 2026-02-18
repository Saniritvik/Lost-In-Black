using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.UI;
using NUnit.Framework.Interfaces;
public class Achievements : MonoBehaviour
{
    public List<AchievementClass> achievements;
    public GameObject crest;
    public GameObject emblem;
    private Image crestImg;
    private Image emblemImg;
    public string searchName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Sun()
    {
        searchName = "The power of the sun is the palm of my hand";
        print(searchName);
        detectAch();
        changeColor();



    }
    private void detectAch()
    {
        AchievementClass result = achievements.Find(x => x.name == searchName);
        print(result);
        crest = result.tab.transform.GetChild(0).gameObject;
        print(crest.name);
        emblem = result.tab.transform.GetChild(1).gameObject;
        print(emblem.name);
        result.unlocked = true;
    }
    private void changeColor()
    {
        crestImg = crest.GetComponent<Image>();
        emblemImg = emblem.GetComponent<Image>();
        crestImg.color = Color.white;
        emblemImg.color = Color.white;
    }
}