using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static rawGenType;
using static buildStateManager;

public class rawGenBuild : MonoBehaviour
{
    public static rawGenBuild RawGenBuild;
    private void Awake() => RawGenBuild = this;
    public List<rawGenType> rawTypeList;
    public List<GameObject> rawGenPrefabs;
    public List<Action> rawGenBuildActions = new List<Action>();
    public List<int> rawGenPrices;

    public static GameObject rawBuildPanel;
    public GameObject rawTypeHolder;

    public static bool rawBuildPanelOpened;

    public Transform genTransform;
    public Transform plotTranform;
    public int selPlotID;

    void Start()
    {
        rawBuildPanel = gameObject.transform.GetChild(0).gameObject;

        foreach(var rawGenType in rawTypeHolder.GetComponentsInChildren<rawGenType>()) rawTypeList.Add(rawGenType);
        
        for (int i = 0; i < rawTypeList.Count; i++) rawTypeList[i].id = i;

        setTypes();
    }

    public static void openRawBuildPanel()
    {
        if(!rawBuildPanelOpened) {rawBuildPanel.SetActive(true); rawBuildPanelOpened = true;}
        else{rawBuildPanel.SetActive(false); rawBuildPanelOpened = false;}
    }

    public void setTypes()
    {
        rawGenBuildActions.Add(buildRaw0);
        rawGenBuildActions.Add(buildRaw1);
    }

    public void buildRaw0()
    {
        print("built gen 0");
    }

    public void buildRaw1()
    {
        print("built gen 1");
    }

    public void setPlotTransform()
    {
       plotTranform = bsManager.rawPlotList[selPlotID].transform;

    }

    public void disablePlot()
    {
        bsManager.rawPlotList[selPlotID].buildPlotPrefab.SetActive(false);
        bsManager.rawPlotList[selPlotID].rawBuildCollider.enabled = !enabled;
    }
}
