using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static rawGenBuild;
using static rawGenType;
using static buildStateManager;

public class rawBuildPlot : MonoBehaviour
{
    public static rawBuildPlot RawBuildPlot;
    void Awake() => RawBuildPlot = this;

    public int plotID;

    public GameObject buildPlotPrefab;
    public BoxCollider rawBuildCollider;

    void Start()
    {
        bsManager.rawPlotList.Add(this);
        rawBuildCollider = GetComponent<BoxCollider>();
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)) {openRawBuildPanel(); RawGenBuild.selectedID = plotID; RawGenBuild.setPlotTransform();}
    }
    
}
