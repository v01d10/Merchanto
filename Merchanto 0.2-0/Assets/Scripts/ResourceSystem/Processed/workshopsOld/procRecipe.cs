using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe")]
public class procRecipe : ScriptableObject
{
    public resRaw rawResource;
    public resProc processedResource;

    public float neededResource;
    public float receivedResource;
    public float price;

    public float procTime;
    public float procTimer;

    public void processResource()
    {
        if(rawResource.resAmount >= neededResource)
        {
            procTimer = procTime;
            procTimer -= Time.deltaTime;
            rawResource.resAmount -= neededResource;

            if(procTimer == 0)
            {
                processedResource.procAmount += receivedResource;
                procTimer = 0;
            }
        }
    }
}
