using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currencyManager : MonoBehaviour
{
    public static currencyManager instance;

    public float Money;
    public float Nuggets;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI nuggetText;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        moneyText.text = Money.ToString("F2") + "$";
        nuggetText.text = Nuggets.ToString("F1");
    }
}
