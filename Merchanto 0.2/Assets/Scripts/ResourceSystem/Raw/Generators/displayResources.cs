using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class displayResources : MonoBehaviour
{
    public resRaw ResRaw;
    public currencyManager currency;

    public Image icon;

    public TextMeshProUGUI nametext;
    public TextMeshProUGUI amountText;
    public TextMeshProUGUI priceText;

    public Button resButton;

[Header("Selling")]
    public GameObject sellBar;

    public Slider sellAmountSlider;
    public Button sellButton;

    public TextMeshProUGUI sellAmountText;
    public TextMeshProUGUI sellPriceText;

    public float sellAmount;
    public float sellMaxAmount;
    public float sellPrice;

    bool sellBarOpened;

    void Start()
    {
        resButton.onClick.AddListener(onResClick);
        sellButton.onClick.AddListener(sellRes);
    }

    void Update()
    {
        icon = ResRaw.resIcon;
        nametext.text = ResRaw.resName;
        amountText.text = ResRaw.resAmount.ToString("F2");
        priceText.text = ResRaw.resPrice.ToString()+"$";

        if(sellBarOpened)
        {
            sellMaxAmount = ResRaw.resAmount;
            sellAmountSlider.maxValue = sellMaxAmount;
            sellAmount = sellAmountSlider.value;
            sellPrice = sellAmount * ResRaw.resPrice;

            sellAmountText.text = sellAmount.ToString("F2");
            sellPriceText.text = sellPrice.ToString("F2");
        }

    }

    public void sellRes()
    {
        ResRaw.resAmount -= sellAmount;
        currency.Money += sellPrice;
        sellBar.SetActive(false);
    }

    void onResClick()
    {
        if(!sellBarOpened && ResRaw.resAmount >= 1)
        {
            sellBar.SetActive(true);
            sellBarOpened = true;
        }
        else
        {
            sellBar.SetActive(false);
            sellBarOpened = false;
        }
    }


}
