using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static rawGenerator;
using static buildStateManager;

public class rawGeneratorUI : MonoBehaviour
{
    public static rawGeneratorUI rawGenUI;
    void Awake() {rawGenUI = this;}

    public string generatorName;
    public TextMeshProUGUI genNameText;

    public GameObject resGenPanel;
    public int selRawID;


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

}


