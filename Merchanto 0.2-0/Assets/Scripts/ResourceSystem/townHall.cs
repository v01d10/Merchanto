using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class townHall : MonoBehaviour
{
    public static townHall TownHall;
    void Awake(){TownHall = this;}
    public float cornAmount;
    public float woodAmount;
    public float ironAmount;

    public Transform THtransportArea;

    void Start()
    {
        THtransportArea = this.transform;
    }
    
}
