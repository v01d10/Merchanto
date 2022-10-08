using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class workshop : MonoBehaviour
{
[Header("Recipes")]
    public procRecipe recipe0;
    public procRecipe recipe1;
    public procRecipe recipe2;
    public procRecipe recipe3;

    public bool pickingRecipe;

[Header("Slot Buttons")]
    public Button slotButt0;
    public Button slotButt1;
    public Button slotButt2;
    public Button slotButt3;

    public GameObject slot0;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public float unlockPrice;
    public TextMeshProUGUI unlockPriceText;

[Header("Recipe Buttons")]
    public GameObject pickRecipePanel;

    public Button recipeButt0;
    public Button recipeButt1;
    public Button recipeButt2;
    public Button recipeButt3;

    public GameObject rec0;
    public GameObject rec0On;
    public GameObject rec1;
    public GameObject rec1On;
    public GameObject rec2;
    public GameObject rec2On;
    public GameObject rec3;
    public GameObject rec3On;

    public TextMeshProUGUI rawAmountText;
    public TextMeshProUGUI procAmountText;
    public TextMeshProUGUI procTimerText;

    public void slotStates()
    {
        if(slot0.activeInHierarchy)
        {
            slotButt0.onClick.AddListener(pickRecipe);
        }
    }

    public void pickRecipe()
    {
        pickRecipePanel.SetActive(true);
        pickingRecipe = true;
    }
    


}
