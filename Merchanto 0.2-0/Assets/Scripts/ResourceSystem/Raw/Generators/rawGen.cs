using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static currencyManager;

[CreateAssetMenu(fileName ="ResGen", menuName ="Resource Generator")]
public class rawGen : ScriptableObject 
{
    public resRaw res0;
    public resRaw res1;
    public resRaw res2;

    public float res0Mined;
    public float res1Mined;
    public float res2Mined;

[Header("Gen Rate")]
    public float genRate;

    public float yield0;
    public float yield1;
    public float yield2;

    public float genRateUpgadePrice;
    public int genRateUpgradeLevel;

[Header("Delivery Speed")]
    public float deliverySpeed;
    public float deliverySpeedPrice;
    public int deliverySpeedLevel;

[Header("Load capacity")]
    public float loadCapacity;
    public float loadCapPrice;
    public int loadCapLevel;


    void Start()
    {
        rawGen RawGen = rawGen.CreateInstance<rawGen>();
    }

    public void genResource()
    {
        if(res0 != null)
        {
            res0Mined += (genRate*yield0)*Time.deltaTime;
            if(res1 != null)
            {
                res1Mined += (genRate*yield1)*Time.deltaTime;                           
                if(res2 != null)
                {
                    res2Mined += (genRate*yield2)*Time.deltaTime;
                }
            }
        }
    }

    public void genRateUp()
    {
        if(CurrencyManager.Money >= genRateUpgadePrice)
        {
            CurrencyManager.Money -= genRateUpgadePrice;
            genRateUpgradeLevel += 1;
            genRateUpgadePrice = genRateUpgadePrice*genRateUpgradeLevel;
            genRate += 0.2f;
        }
        else
        {
            Debug.Log("Not enough money...");
        }
    }

    public void delSpeedUp()
    {
        if(CurrencyManager.Money >= deliverySpeedPrice)
        {
            CurrencyManager.Money -= deliverySpeedPrice;
            deliverySpeedLevel += 1;
            deliverySpeedPrice = deliverySpeedPrice*deliverySpeedLevel;
            deliverySpeed += 0.03f;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void loadCapUp()
    {
        if(CurrencyManager.Money >= loadCapPrice)
        {
            CurrencyManager.Money -= loadCapPrice;
            loadCapLevel += 1;
            loadCapPrice = loadCapPrice*loadCapLevel;
            loadCapacity += loadCapacity * 0.2f;
        }
        else
        {
            Debug.Log("Not enough money");
        }      
    }

}
