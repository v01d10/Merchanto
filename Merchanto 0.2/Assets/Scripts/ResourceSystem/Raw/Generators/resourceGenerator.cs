using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static currencyManager;

public class resourceGenerator : MonoBehaviour
{
    public rawGen RawGen;
    
    public string generatorName;
    public TextMeshProUGUI genNameText;

    public GameObject resGenPanel;
    public bool resGenPanelOpened;

[Header("Gen Rate")]
    public TextMeshProUGUI genRateLvlText;
    public TextMeshProUGUI genRateText;
    public TextMeshProUGUI genRatePriceText;
    
    public Button rateUpButton;

[Header("Delivery Speed")]
    public TextMeshProUGUI delSpeedLvlText;
    public TextMeshProUGUI delSpeedText;
    public TextMeshProUGUI delSpeedPriceText;

    public Button speedUpButton;

[Header("Load capacity")]
    public TextMeshProUGUI loadCapLvlText;
    public TextMeshProUGUI loadCapText;
    public TextMeshProUGUI loadCapPriceText;

    public Button capUpButtton;

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
    public transport Trans;
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
            RawGen.genResource();
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && state0Active && CurrencyManager.Money >= buildPrice)
        {
            buildGen();
        }

        if(Input.GetMouseButtonDown(0) && !resGenPanelOpened && state1Active)
        {
            openGenPanel();
        }
        
        else if(Input.GetMouseButtonDown(0) && resGenPanelOpened)
        {
            resGenPanel.SetActive(false);
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
            genNameText.text = generatorName;
            resGenPanel.SetActive(true);
            resGenPanelOpened = true;

            activateUpgradeButtons();

            updateRateText();
            updateSpeedText();
            updateCapText();  
    }

    public void activateUpgradeButtons()
    {
        rateUpButton.onClick.AddListener(RawGen.genRateUp);
        rateUpButton.onClick.AddListener(updateRateText);

        speedUpButton.onClick.AddListener(RawGen.delSpeedUp);
        speedUpButton.onClick.AddListener(updateSpeedText);

        capUpButtton.onClick.AddListener(RawGen.loadCapUp);
        capUpButtton.onClick.AddListener(updateCapText);
    }

    public void updateRateText()
    {
        genRateLvlText.text = RawGen.genRateUpgradeLevel.ToString();
        genRateText.text = RawGen.genRate.ToString("F2");
        genRatePriceText.text = RawGen.genRateUpgadePrice.ToString("F2");
    }

    public void updateSpeedText()
    {
        delSpeedLvlText.text = RawGen.deliverySpeedLevel.ToString();
        delSpeedText.text = RawGen.deliverySpeed.ToString("F2");
        delSpeedPriceText.text = RawGen.deliverySpeedPrice.ToString("F2");
    }

    public void updateCapText()
    {  
        loadCapLvlText.text = RawGen.loadCapLevel.ToString();
        loadCapText.text = RawGen.loadCapacity.ToString("F2");
        loadCapPriceText.text = RawGen.loadCapPrice.ToString("F2");
    }



}
