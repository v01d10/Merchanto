using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class resourceGenerator : MonoBehaviour
{
    public resGen ResGen;

    public GameObject resGenPanel;

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

    bool state0Active = true;
    bool state1Active = false;

[Header("Transport")]
    public transport Trans;

    void Start()
    {
        activateButtons();

        updateRateText();
        updateSpeedText();
        updateCapText();
    }

    void Update()
    {
        StateMachine();
        ResGen.genResource();
    }

    public void StateMachine()
    {
        if(state0Active)
        {
            state0.SetActive(true);
        }
        else if(state1Active)
        {
            state0Active = false;

            state0.SetActive(false);
            state1.SetActive(true);
        }
    }

    public void activateButtons()
    {
        rateUpButton.onClick.AddListener(ResGen.genRateUp);
        rateUpButton.onClick.AddListener(updateRateText);

        speedUpButton.onClick.AddListener(ResGen.delSpeedUp);
        speedUpButton.onClick.AddListener(updateSpeedText);

        capUpButtton.onClick.AddListener(ResGen.loadCapUp);
        capUpButtton.onClick.AddListener(updateCapText);
    }

    public void updateRateText()
    {
        genRateLvlText.text = ResGen.genRateUpgradeLevel.ToString();
        genRateText.text = ResGen.genRate.ToString("F2");
        genRatePriceText.text = ResGen.genRateUpgadePrice.ToString("F2");
    }

    public void updateSpeedText()
    {
        delSpeedLvlText.text = ResGen.deliverySpeedLevel.ToString();
        delSpeedText.text = ResGen.deliverySpeed.ToString("F2");
        delSpeedPriceText.text = ResGen.deliverySpeedPrice.ToString("F2");
    }

    public void updateCapText()
    {  
        loadCapLvlText.text = ResGen.loadCapLevel.ToString();
        loadCapText.text = ResGen.loadCapacity.ToString("F2");
        loadCapPriceText.text = ResGen.loadCapPrice.ToString("F2");
    }



}
