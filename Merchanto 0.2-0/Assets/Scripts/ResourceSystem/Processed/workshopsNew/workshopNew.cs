using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =("Generators/Processed"))]
public class workshopNew : ScriptableObject
{
    public enum procType {proc0, proc1, proc2}
    
    public procType type;

[Header("Input Materials")]
    public resRaw input0;
    public resRaw input1;
    public resRaw input2;

[Header("Output Materials")]
    public resProc output0;
    public resProc output1;
    public resProc output2;

[Header("Stats")]
    public string shopName; 
    public float neededPer1Amount;
    public float receivedAount;
    public float workers;
    public float maxWorkers;
    public float buildingLvl;
    public float upgradePrice;

[Header("Timer")]
    public float procTime;
    public static float procTime1;
    public float procTimer;
    public WaitForSeconds procWait = new WaitForSeconds(10);
    public bool timerRunning;

[Header("Booleans")]
    public bool locked;
    public bool active;
    public bool gotRes;
    public bool switchedType;

    public bool processing0;
    public bool processing1;
    public bool processing2;

    public void StateMachine()
    {
        if(type == procType.proc0)
        {
            processing0 = true;
            processing1 = false;
            processing2 = false;
        }
        else if(type == procType.proc1)
        {
            processing0 = false;
            processing1 = true;
            processing2 = false;
        }
        else if(type == procType.proc2)
        {
            processing0 = false;
            processing1 = false;
            processing2 = true;
        }
    }


    public void checkResource()
    {
        if(input0.resAmount >= neededPer1Amount)
            gotRes = true;
        else if(input1.resAmount >= neededPer1Amount)
            gotRes = true;
        else if(input2.resAmount >= neededPer1Amount)
            gotRes = true;
        else
            gotRes = false;
    }





    

}
