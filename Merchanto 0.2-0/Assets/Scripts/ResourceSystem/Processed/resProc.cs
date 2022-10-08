using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName =("ResourceProcessed"), menuName =("Resource/Processed"))]
public class resProc : ScriptableObject

{
    public Image procIcon;

    public string procName;
    public float procAmount;
    public float procPrice;
}
