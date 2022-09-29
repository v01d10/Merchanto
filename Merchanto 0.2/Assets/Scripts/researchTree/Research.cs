using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static ResearchTree;

public class Research : MonoBehaviour
{
    public int id;

    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public int[] connectedResearches;

    public currencyManager CM;

[Header("My Stuff")]
    public Image researchIcon;
    public Sprite onSprite;
    public Sprite offSprite;
    public Image researchImage;
    public Button researchNodeButt;
    public Button researchButt;
    public Button closeResearchButt;
    public Button buyResearchButt;
    public bool researchPanelOpened;
    public GameObject researchPanel;


    void Start()
    {
        closeResearchButt.onClick.AddListener(closeResearch);
    }

    public void UpdateUI()
    {
        titleText.text = $"{researchTree.researchNames[id]}";
        descriptionText.text = $"{researchTree.researchDescriptions[id]}\nCost: {researchTree.researchPrices[id]} $";

        researchIcon.sprite = researchPanelOpened ? researchTree.researchIcons[id] : null;

        researchImage.sprite = researchTree.researchLevels[id] >= researchTree.researchCaps[id] ? researchImage.sprite = offSprite
        : CM.Money >= researchTree.researchPrices[id] ? researchTree.researchIcons[id] : researchTree.researchIcons[id];

        //researchNodeButt.enabled = researchTree.researchLevels[id] >= researchTree.researchCaps[id] ? !researchNodeButt.enabled : researchNodeButt.enabled;

        foreach (var ConnectedResearches in connectedResearches)
        {
            researchTree.researchList[ConnectedResearches].gameObject.SetActive(researchTree.researchLevels[id] > 0);
            researchTree.connectorList[ConnectedResearches].SetActive(researchTree.researchLevels[id] > 0);
        }
    }

    public void Buy()
    {
        if(researchTree.researchPrices[id] >= CM.Money || researchTree.researchLevels[id] >= researchTree.researchCaps[id]) return;
        CM.Money -= researchTree.researchPrices[id];
        researchTree.researchLevels[id]++;
        researchTree.UpdateAllSkillUI();

        ResearchTree.upgrades[id]();
        researchNodeButt.enabled = !researchNodeButt.enabled;
        closeResearch();
    }

    public void onResearchClick()
    {
        if (!researchPanelOpened) {researchPanel.SetActive(true); researchPanelOpened = true; UpdateUI(); buyResearchButt.onClick.AddListener(Buy);}
    }

    public void closeResearch()
    {
        if (researchPanelOpened) {researchPanel.SetActive(false); researchPanelOpened = false; UpdateUI(); researchButt.onClick.RemoveAllListeners(); buyResearchButt.onClick.RemoveAllListeners();}
    }

}
