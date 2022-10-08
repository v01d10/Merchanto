using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currencyManager : MonoBehaviour
{
    public static currencyManager CurrencyManager;
    void Awake(){CurrencyManager = this;}
    
    public float Money;
    public float Nuggets;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI nuggetText;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) Money += 1000;
        moneyText.text = Money.ToString("F2") + "$";
        nuggetText.text = Nuggets.ToString("F1");
    }
}
