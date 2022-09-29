using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static rawGenBuild;
using static rawGenType;

public class rawBuildPlot : MonoBehaviour
{
    public static rawBuildPlot RawBuildPlot;
    void Awake() => RawBuildPlot = this;

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)) {openRawBuildPanel();}
    }

    public void switchRawModel()
    {
        this.gameObject.SetActive(false);

    }
}
