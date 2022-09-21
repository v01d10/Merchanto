using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName =("ResourceRaw"), menuName =("Resource/Raw"))]
public class resRaw : ScriptableObject
{
    public Image resIcon;

    public string resName;
    public float resAmount;
    public float resPrice;
}
