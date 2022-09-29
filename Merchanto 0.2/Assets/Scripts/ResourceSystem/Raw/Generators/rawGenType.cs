using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static rawGenBuild;
using static rawBuildPlot;
using static currencyManager;

public class rawGenType : MonoBehaviour
{
    public static rawGenType RawGenType;
    void Awake() => RawGenType = this;

    public int id;
    
    public void build()
    { 
        if(CurrencyManager.Money >= RawGenBuild.rawGenPrices[id])
        {
            rawGenBuild.openRawBuildPanel();
            RawGenBuild.rawGenTypes[id]();

            RawBuildPlot.switchRawModel();

            CurrencyManager.Money -= RawGenBuild.rawGenPrices[id];
        }

    }
}
