using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class townfolk : MonoBehaviour
{
    public townfolkManager tM;
    public string Name;
    public int Age;

    public float Happiness;
    public float Hunger;
    public float needForAlcohol;
    public float alcoholAdiction;

    public bool Man;
    public bool gotClothes;
    public bool gotWork;

    public static townfolk Townfolk;

    private townfolk(string tName, int tAge, bool tMan)
    {
        Name = tName;
        Age = tAge;
    }

    void Start()
    {
        tM = GetComponentInParent<townfolkManager>();
        setFolk();
    }

    void Update()
    {
        Hunger += Time.deltaTime/10;

        handleAlcohol();
    }

    public void setFolk()
    {
        int mNameID = UnityEngine.Random.Range(0, tM.mNames.Count);
        int fNameID = UnityEngine.Random.Range(0, tM.fNames.Count);
        int tAge = UnityEngine.Random.Range(5, 51);

        if(UnityEngine.Random.value >= 0.5)
        {
            Name = tM.mNames[mNameID];
            Age = tAge;
            Man = true;

            alcoholAdiction = UnityEngine.Random.Range(0, 25);

            tM.addFolk(this);
            tM.freeTownfolksAmount++;
        }
        else
        {
            Name = tM.fNames[fNameID];
            Age = tAge;
            Man = false;

            alcoholAdiction = UnityEngine.Random.Range(0, 25);

            tM.addFolk(this);
            tM.freeTownfolksAmount++;
        }
    }


    void handleAlcohol()
    {
        if(alcoholAdiction >= 10) needForAlcohol += Time.deltaTime/10;
        else if(alcoholAdiction >= 20) needForAlcohol += Time.deltaTime/9;
        else if(alcoholAdiction >= 40) needForAlcohol += Time.deltaTime/8;
        else if(alcoholAdiction >= 60) needForAlcohol += Time.deltaTime/7;
        else if(alcoholAdiction >= 70) needForAlcohol += Time.deltaTime/6;
        else if(alcoholAdiction >= 90) needForAlcohol += Time.deltaTime/5;
    }


}
