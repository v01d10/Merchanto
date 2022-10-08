using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static rawGeneratorUI;
using static rawBuildPlot;
using static buildStateManager;
using static currencyManager;

public class rawGenerator : MonoBehaviour
{
    public static rawGenerator RawGenerator;
    void Awake() {RawGenerator = this;}
    public bool resGenPanelOpened;

    public int rawGenID;

    public resRaw res0;
    public resRaw res1;
    public resRaw res2;

    public float res0Mined;
    public float res1Mined;
    public float res2Mined;

    public float yield0;
    public float yield1;
    public float yield2;


[Header("Upgrades")]
    public float genRateLvl;
    public float genRate;
    public float genRatePrice;

    public float delSpeedLvl;
    public float delSpeed;
    public float delSpeedPrice;

    public float loadCapLvl;
    public float loadCap;
    public float loadCapPrice;

[Header("Building States")]
    public GameObject state0;
    public GameObject state1;

    public GameObject priceTag;
    public TextMeshProUGUI priceText;
    public float buildPrice;

    public bool state0Active = true;
    public bool state1Active = false;
    
    public buildMenu BuildMenu;

[Header("Transport")]
    public GameObject transport;

    void Start()
    {
        priceText.text = buildPrice.ToString() + "$";

        if(resGenPanelOpened)
        {
            activateUpgradeButtons();

            updateRateText();
            updateSpeedText();
            updateCapText();           
        }
    }

    void Update()
    {
        StateMachine();
    }

    public void StateMachine()
    {
        if(state0Active)
        {
            state0.SetActive(true);
            priceTag.SetActive(true);
            transport.SetActive(false);
        }
        else if(state1Active)
        {
            genResource();
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && state0Active && CurrencyManager.Money >= buildPrice)
        {
            buildGen();
            bsManager.rawGenList.Add(this);
            rawGenID = bsManager.rawGenList.IndexOf(this);
            transport.GetComponent<rawTransport>().rawParentID = rawGenID;
        }

        if(Input.GetMouseButtonDown(0) && !resGenPanelOpened && state1Active)
        {
            rawGenUI.selRawID = rawGenID;
            openGenPanel();
        }
        
        else if(Input.GetMouseButtonDown(0) && resGenPanelOpened)
        {
            rawGenUI.resGenPanel.SetActive(false);
            resGenPanelOpened = false;
        }
    }

    public void buildGen()
    {
            CurrencyManager.Money -= buildPrice;
            state0Active = false;
            state1Active = true;

            state1.SetActive(true);
            state0.SetActive(false);
            priceTag.SetActive(false);
            transport.SetActive(true);
    }

    public void openGenPanel()
    {
            rawGenUI.genNameText.text = rawGenUI.generatorName;
            rawGenUI.resGenPanel.SetActive(true);
            resGenPanelOpened = true;

            activateUpgradeButtons();

            updateRateText();
            updateSpeedText();
            updateCapText();  
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
        if(CurrencyManager.Money >= genRatePrice)
        {
            CurrencyManager.Money -= bsManager.rawGenList[rawGenUI.selRawID].genRatePrice;
            bsManager.rawGenList[rawGenUI.selRawID].genRateLvl += 1;
            bsManager.rawGenList[rawGenUI.selRawID].genRatePrice = bsManager.rawGenList[rawGenUI.selRawID].genRatePrice * bsManager.rawGenList[rawGenID].genRateLvl;
            bsManager.rawGenList[rawGenUI.selRawID].genRate += 0.2f;
        }
        else
        {
            Debug.Log("Not enough money...");
        }
    }

    public void delSpeedUp()
    {
        if(CurrencyManager.Money >= delSpeedPrice)
        {
            CurrencyManager.Money -= delSpeedPrice;
            delSpeedLvl += 1;
            delSpeedPrice = delSpeedPrice*delSpeedLvl;
            delSpeed += 0.03f;
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
            loadCapLvl += 1;
            loadCapPrice = loadCapPrice*loadCapLvl;
            loadCap += loadCap * 0.2f;
        }
        else
        {
            Debug.Log("Not enough money");
        }      
    }

    public void activateUpgradeButtons()
    {
        rawGenUI.rateUpButton.onClick.AddListener(bsManager.rawGenList[rawGenUI.selRawID].genRateUp);
        rawGenUI.rateUpButton.onClick.AddListener(updateRateText);

        rawGenUI.speedUpButton.onClick.AddListener(bsManager.rawGenList[rawGenUI.selRawID].delSpeedUp);
        rawGenUI.speedUpButton.onClick.AddListener(updateSpeedText);

        rawGenUI.capUpButtton.onClick.AddListener(bsManager.rawGenList[rawGenUI.selRawID].loadCapUp);
        rawGenUI.capUpButtton.onClick.AddListener(updateCapText);
    }

    public void updateRateText()
    {
        rawGenUI.genRateLvlText.text = bsManager.rawGenList[rawGenUI.selRawID].genRateLvl.ToString();
        rawGenUI.genRateText.text = bsManager.rawGenList[rawGenUI.selRawID].genRate.ToString("F2");
        rawGenUI.genRatePriceText.text = bsManager.rawGenList[rawGenUI.selRawID].genRatePrice.ToString("F2");
    }

    public void updateSpeedText()
    {
        rawGenUI.delSpeedLvlText.text = bsManager.rawGenList[rawGenUI.selRawID].delSpeedLvl.ToString();
        rawGenUI.delSpeedText.text = bsManager.rawGenList[rawGenUI.selRawID].delSpeed.ToString("F2");
        rawGenUI.delSpeedPriceText.text = bsManager.rawGenList[rawGenUI.selRawID].delSpeedPrice.ToString("F2");
    }

    public void updateCapText()
    {  
        rawGenUI.loadCapLvlText.text = bsManager.rawGenList[rawGenUI.selRawID].loadCapLvl.ToString();
        rawGenUI.loadCapText.text = bsManager.rawGenList[rawGenUI.selRawID].loadCap.ToString("F2");
        rawGenUI.loadCapPriceText.text = bsManager.rawGenList[rawGenUI.selRawID].loadCapPrice.ToString("F2");
    }
}

