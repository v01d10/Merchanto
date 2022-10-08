using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static rawGenBuild;
using static rawGenType;
using static buildStateManager;
using UnityEngine.EventSystems;

public class rawBuildPlot : MonoBehaviour
{
    public static rawBuildPlot RawBuildPlot;
    void Awake() => RawBuildPlot = this;

    public int plotID;

    public GameObject buildPlotPrefab;
    public BoxCollider rawBuildCollider;
    public Transform genTransform;

    void Start()
    {
        bsManager.rawPlotList.Add(this);
        rawBuildCollider = GetComponent<BoxCollider>();
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && ! EventSystem.current.IsPointerOverGameObject()) {openRawBuildPanel(); RawGenBuild.selPlotID = plotID; RawGenBuild.setPlotTransform();}
    }
    
}
