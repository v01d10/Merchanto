using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceManager : MonoBehaviour
{
    public bool bindedRaw;
    public bool bindedProc;

[Header("Resource Raw")]
    public resRaw raw0;
    public resRaw raw1;
    public resRaw raw2;

[Header("Resource Processed")]
    public resProc proc0;
    public resProc proc1;
    public resProc proc2;

[Header("Amounts Raw")]
    public float amountRaw0;
    public float amountRaw1;
    public float amountRaw2;

[Header("Ammounts processed")]
    public float amountProc0;
    public float amountProc1;
    public float amountProc2;

    void Update()
    {
        
        bindAmountRaw();
        

        bindAmountProc();
    }

    public void bindAmountRaw()
    {
        amountRaw0 = raw0.resAmount;
        amountRaw1 = raw1.resAmount;
        amountRaw2 = raw2.resAmount;

        raw0.resAmount = amountRaw0;
        raw1.resAmount = amountRaw1;
        raw2.resAmount = amountRaw2;
    }

    public void bindAmountProc()
    {
        amountProc0 = proc0.procAmount;
        amountProc1 = proc1.procAmount;
        amountProc2 = proc2.procAmount;
    }
}
