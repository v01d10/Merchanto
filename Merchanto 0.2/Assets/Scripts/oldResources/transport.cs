using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class transport : MonoBehaviour
{
    public resGen ResGen;
    public resRaw ResRaw;
    public resourceGenerator ResGenerator;

    public float speed;
    public float carryAmount;
    public float canCarryAmount;

    public Transform townHall;
    public Transform transportPoint;

    public bool carryResource;
    public bool pickedResource;
    public bool returning;

    public NavMeshAgent worker;

    void Start()
    {
        transportPoint =  this.transform.parent;

        returning = true;
    }

    void Update()
    {
        StateMachine();

        speed = ResGen.deliverySpeed;
        worker.speed = speed;
    }

    public void StateMachine()
    {
        if(carryResource && !returning)
        {
            worker.SetDestination(townHall.transform.position);
        }

        if(returning && !carryResource)
        {
            worker.SetDestination(transportPoint.transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ResGen"))
        {
            if(ResGen.res0Mined <= ResGen.loadCapacity && !pickedResource)
            {
                canCarryAmount += ResGen.res0Mined;
                carryAmount = canCarryAmount;
                ResGen.res0Mined -= carryAmount;

                returning = false;
                carryResource = true;
                pickedResource = true;
            }
            else if(ResGen.res0Mined >= ResGen.loadCapacity && !pickedResource)
            {
                ResGen.res0Mined -= ResGen.loadCapacity;
                carryAmount += ResGen.loadCapacity;

                returning = false;
                carryResource = true;
                pickedResource = true;
            }

        }
        else if(other.CompareTag("TownHall"))
        {
            ResRaw.resAmount += carryAmount;
            carryAmount -= carryAmount;
            canCarryAmount = 0;

            returning = true;
            carryResource = false;
            pickedResource = false;
        }
    }
}
