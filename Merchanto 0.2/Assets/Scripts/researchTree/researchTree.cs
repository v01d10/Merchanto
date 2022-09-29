using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResearchTree : MonoBehaviour
{
    public static ResearchTree researchTree;
    private void Awake() => researchTree = this;

    public int[] researchLevels;
    public int[] researchCaps;
    public int[] researchPrices;
    public string[] researchNames;
    public string[] researchDescriptions;
    public Sprite[] researchIcons;

    public static List<Action> upgrades = new List<Action>();

    public List<Research> researchList;
    public GameObject researchHolder;

    public List<GameObject> connectorList;
    public GameObject connectorHolder;

    public currencyManager CM;
    public researchUpgrades RU;

    private void Start()
    {
        researchLevels = new int[6];

        foreach (var Research in researchHolder.GetComponentsInChildren<Research>()) researchList.Add(Research);
        foreach (var Connector in connectorHolder.GetComponentsInChildren<RectTransform>()) connectorList.Add(Connector.gameObject);

        for (int i = 0; i < researchList.Count; i++) researchList[i].id = i;

        UpdateAllSkillUI();

        upgrades.Add(upgrade0);
    }

    public void UpdateAllSkillUI()
    {
        foreach (var Research in researchList) Research.UpdateUI();
    }

    public void upgrade0()
    {
        Debug.Log(("upgrade0 acquired"));
    }






}