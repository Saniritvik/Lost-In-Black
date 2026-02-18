using System.Runtime.CompilerServices;
using TMPro;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int scraps = 0;
    public int healCost = 10;
    public int heavyCost = 100;
    public int lightCost = 20;
    public int baseCost = 50;
    public int slingerUpgrade2Cost = 50;
    public int slingerUpgrade3Cost = 200;
    public int bCost = 1000;
    public int bUpgrade2Cost = 2000;
    public int bUpgrade3Cost = 4000;
    public int burstCost = 100;
    public int burst2Cost = 200;
    public int burst3Cost = 300;
    public int pierceCost = 200;
    public int pierceUpgrade2Cost = 500;
    public int pierceUpgrade3Cost = 700;
    public int lightScrapMult = 2;
    public TextMeshProUGUI scrapCounter;
    public TextMeshProUGUI scrapNeeded;
    public GameObject scrapNeededGO;
    public Movement movement;
    public Achievements achievement;
    public cycle cycles;
    public AudioSource no;
    public bool basic = true;
    public bool burst;
    public bool b;
    public bool pierce;
    public bool basicA;
    public bool lightA;
    public bool heavyA;
    public int burstDamageUp = 1;
    public int pierceDamageUp = 0;
    public int slingerDamageUp = 0;
    public float burstFireRateUp = 0;
    public int bFireRateUp = 0;
    public TextMeshProUGUI burstUpgradeText;
    public TextMeshProUGUI burstDescText;
    public TextMeshProUGUI slingerUpgradeText;
    public TextMeshProUGUI slingerDescText;
    public TextMeshProUGUI bUpgradeText;
    public TextMeshProUGUI bDescText;
    public TextMeshProUGUI pierceUpgradeText;
    public TextMeshProUGUI pierceDescText;
    private bool levelBurstThree = false;
    private bool levelSlingerThree = false;
    private bool levelbThree = false;
    private bool levelPierceThree = false;
    private bool burstMaxed = false;
    private bool bMaxed = false;
    private bool slingerMaxed = false;
    private bool pierceMaxed = false;
    public bool slinger = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = FindFirstObjectByType<Movement>();
        cycles = FindFirstObjectByType<cycle>();
        achievement = FindFirstObjectByType<Achievements>();
    }

    // Update is called once per frame
    void Update()
    {
        scrapCounter.text = scraps.ToString();
    }
    public void collectScrap()
    {
        if (!movement.light)
        {
            scraps += 10;
        }
        else
        {
            scraps += 10 * lightScrapMult;
        }
    }

    public bool PriceCheck(int playerScrap, int itemCost, bool shouldShowMessage = true)
    {
        bool canAfford = (playerScrap - itemCost) >= 0;

        if (canAfford)
        {
            scrapNeededGO.SetActive(false);
            return true;
        }
        else if (shouldShowMessage)
        {
            scrapNeededGO.SetActive(true);
            scrapNeeded.text = "You need at least " + itemCost.ToString() + " scrap to purchase this item!";
        }

        return false;
    }
    public void heal()
    {
        if (PriceCheck(scraps, healCost))
        {
            if (movement.healthPoint < movement.maxHealth)
            {
                movement.healthPoint += 10;
                scraps -= healCost;
            }
            else
            {
                if (no != null)
                {
                    no.Play();
                }
            }
        }
    }
    public void heavyArmorBuy()
    {
        if (PriceCheck(scraps,heavyCost) && !heavyA)
        {
           heavyA = true;
        }
    }
    public void lightArmorBuy()
    {
        if (PriceCheck(scraps, lightCost) && !lightA)
        {
           lightA = true;
        }
    }
    public void baseArmorBuy()
    {
        if (PriceCheck(scraps, baseCost) && !basicA)
        {
            basicA = true;
        }
    }
    public void burstBuy()
    {
        // Return values here are used to shortcircuit the program to guarntee it doesn't execute multiple times

        if (!burst) { 
            if (PriceCheck(scraps, burstCost))
            {
                burst = true;
                cycles.availableWeopons.Add(cycles.weapons[1]);
                scraps -= burstCost;
                burstUpgradeText.text = "Burst lv. 2";
                burstDescText.text = "10 damage + 0.5 fire rate";
            }
            return;
        }

        if (!levelBurstThree)
        {
            if (PriceCheck(scraps, burst2Cost))
            {
                burstDamageUp = 2;
                burstFireRateUp = -0.5f;
                scraps -= burst2Cost;
                burstUpgradeText.text = "Burst lv. 3";
                levelBurstThree = true;
                burstDescText.text = "20 damage";
            }
            return;
        }
        
        if (burstMaxed)
        {
            burstDescText.text = "No more upgrades!";
            scrapNeededGO.SetActive(false);
            return;
        }

        if (PriceCheck(scraps, burst3Cost))
        {
            burstDamageUp = 4;
            scraps -= burst3Cost;
            burstUpgradeText.text = "Burst MAXED";
            burstDescText.text = "MAXED";
            burstMaxed = true;
        }
    }

    public void SlingerBuy()
    {
        if (!slinger) {
            if (PriceCheck(scraps, slingerUpgrade2Cost))
            {
                slingerDamageUp = 2;
                slinger = true;
                scraps -= slingerUpgrade2Cost;
                slingerUpgradeText.text = "Slinger lv. 2";
                slingerDescText.text = "10 damage";
            }
            return;
        }

        if (!levelSlingerThree) {
            if (PriceCheck(scraps, slingerUpgrade3Cost))
            {
                slingerDamageUp = 5;
                scraps -= slingerUpgrade3Cost;
                slingerUpgradeText.text = "Slinger MAXED";
                levelSlingerThree = true;
                slingerMaxed = true;
                slingerDescText.text = "MAXED";
            }
            return;
        }
        if (slingerMaxed)
        {
            slingerDescText.text = "No more upgrades!";
            scrapNeededGO.SetActive(false);
            return;
        }
    }

    public void bBuy()
    {
        if (!b) {
            if (PriceCheck(scraps, bCost))
            {
                b = true;
                cycles.availableWeopons.Add(cycles.weapons[2]);
                scraps -= bCost;
                bUpgradeText.text = "Black Hole lv. 2";
                bDescText.text = "7 fire rate";
            }
            return;
        }

        if (!levelbThree) {
            if (PriceCheck(scraps, bUpgrade2Cost))
            {
                bFireRateUp = -2;
                scraps -= bUpgrade2Cost;
                levelbThree = true;
                bUpgradeText.text = "Black Hole lv. 3";
                bDescText.text = "5 fire rate";
            }
            return;
        }
        if (bMaxed)
        {
            bDescText.text = "No more upgrades!";
            scrapNeededGO.SetActive(false);
            return;
        }
        if (PriceCheck(scraps, bUpgrade3Cost))
        {
            bFireRateUp = -5;
            scraps -= bUpgrade3Cost;
            bUpgradeText.text = "Black Hole MAXED";
            bDescText.text = "MAXED";
            bMaxed = true;
        }
    }
    public void pierceBuy()
    {
        if (!pierce) {
            if (PriceCheck(scraps, pierceCost))
            {
                pierce = true;
                cycles.availableWeopons.Add(cycles.weapons[3]);
                scraps -= pierceCost;
                achievement.Sun();
                pierceUpgradeText.text = "Piercer lv. 2";
                pierceDescText.text = "30 damage";
            }
            return;
        }

        if (!levelPierceThree) {
            if (PriceCheck(scraps, pierceUpgrade2Cost))
            {
                pierceDamageUp = 10;
                scraps -= pierceUpgrade2Cost;
                levelPierceThree = true;
                pierceUpgradeText.text = "Piercer lv. 3";
                pierceDescText.text = "40 damage";
            }
            return;
        }
        if (pierceMaxed)
        {
            pierceDescText.text = "No more upgrades!";
            scrapNeededGO.SetActive(false);
            return;
        }

        if (PriceCheck(scraps, pierceUpgrade3Cost))
        {
            pierceDamageUp = 20;
            scraps -= pierceUpgrade3Cost;
            pierceUpgradeText.text = "Piercer MAXED";
            pierceDescText.text = "MAXED";
            pierceMaxed = true;
        }
    }
}
