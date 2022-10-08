using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static rawGenBuild;
using static rawBuildPlot;
using static currencyManager;
using static buildStateManager;

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
            RawGenBuild.rawGenBuildActions[id]();

            CurrencyManager.Money -= RawGenBuild.rawGenPrices[id];
            
            Instantiate(RawGenBuild.rawGenPrefabs[id], RawGenBuild.plotTranform);
            RawGenBuild.disablePlot();
    
            print(RawGenBuild.selPlotID);

        }

    }
}
