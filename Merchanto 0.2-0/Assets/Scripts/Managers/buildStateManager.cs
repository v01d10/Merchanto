using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildStateManager : MonoBehaviour
{
    public static buildStateManager bsManager;
    void Awake() {bsManager = this;}
    
[Header("Build levels")]
    public static bool buildLvl0;
    public static bool buildLvl1;
    public static bool buildLvl2;
    public static bool buildLvl3;
    public static bool buildlvl4;

    public GameObject buildLandPrefab;

    Vector3 position;

    float buildings;
    float maxBuildings = 3;

    public List<rawBuildPlot> rawPlotList = new List<rawBuildPlot>();
    public List<rawGenerator> rawGenList = new List<rawGenerator>();

    public GameObject ground;

    void Start()
    {
        Invoke("setPlotID", 1);
    }

    void Update()
    {
        if(buildings <= maxBuildings) {position = new Vector3(Random.Range(-5, 5), 1, Random.Range(5, 5)); Instantiate(buildLandPrefab, position, Quaternion.identity); buildings++;} 
    }

    public void setPlotID()
    {
        for (int i = 0; i < rawPlotList.Count; i++) rawPlotList[i].plotID = i;
        for (int i = 0; i < rawGenList.Count; i++) rawGenList[i].rawGenID = i;

    }
}
