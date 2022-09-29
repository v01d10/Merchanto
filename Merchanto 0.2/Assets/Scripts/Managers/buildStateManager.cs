using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildStateManager : MonoBehaviour
{
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

    void Update()
    {
        if(buildings <= maxBuildings) {position = new Vector3(Random.Range(-5, 5), 1, Random.Range(5, 5)); Instantiate(buildLandPrefab, position, Quaternion.identity); buildings++;} 

    }
}
