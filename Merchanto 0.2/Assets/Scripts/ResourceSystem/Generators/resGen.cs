using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="ResGen", menuName ="Resource Generator")]
public class resGen : ScriptableObject 
{
    public resRaw res0;
    public resRaw res1;
    public resRaw res2;

    public float res0Mined;
    public float res1Mined;
    public float res2Mined;

[Header("Gen Rates")]
    public float genRate;

    public float yield0;
    public float yield1;
    public float yield2;

[Header("Gen Rate Upgrade")]
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

[Header("References")]
    public resourceGenerator resourceGen; 

    void Start()
    {
        resGen ResGen = resGen.CreateInstance<resGen>();
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
        if(currencyManager.instance.Money >= genRateUpgadePrice)
        {
            currencyManager.instance.Money -= genRateUpgadePrice;
            genRateUpgradeLevel += 1;
            genRateUpgadePrice += genRateUpgadePrice;
            genRate += 0.3f;
        }
        else
        {
            Debug.Log("Not enough money...");
        }
    }

    public void delSpeedUp()
    {
        if(currencyManager.instance.Money >= deliverySpeedPrice)
        {
            currencyManager.instance.Money -= deliverySpeedPrice;
            deliverySpeedLevel += 1;
            deliverySpeedPrice += deliverySpeedPrice;
            deliverySpeed += 0.3f;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void loadCapUp()
    {
        if(currencyManager.instance.Money >= loadCapPrice)
        {
            currencyManager.instance.Money -= loadCapPrice;
            loadCapLevel += 1;
            loadCapPrice += loadCapPrice;
            loadCapacity += loadCapacity * 0.5f;
        }
        else
        {
            Debug.Log("Not enough money");
        }      
    }

}
