using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class resourceGenerator : MonoBehaviour
{
    public resGen resGenerator;

    public GameObject resGenPanel;

[Header("Gen Rate")]
    public TextMeshProUGUI genRateLvlText;
    public TextMeshProUGUI genRateText;
    public TextMeshProUGUI genRatePriceText;

[Header("Delivery Speed")]
    public TextMeshProUGUI delSpeedText;

[Header("Load capacity")]
    public TextMeshProUGUI loadCapText;

[Header("Building States")]
    public GameObject state0;
    public GameObject state1;

    bool state0Active = true;
    bool state1Active = false;

[Header("Transport")]
    public transport Trans;

    void Update()
    {
        StateMachine();
        resGenerator.genResource();

        genRateLvlText.text = resGenerator.genRateUpgradeLevel.ToString();
        genRateText.text = resGenerator.genRate.ToString("F2");
        genRatePriceText.text = resGenerator.genRateUpgradeLevel.ToString("F2");
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
}
