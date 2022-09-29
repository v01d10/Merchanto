using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class transport : MonoBehaviour
{
    public rawGen RawGen;

[Header("Resources")]
    public resRaw res0;   
    public resRaw res1;
    public resRaw res2;

[Header("Transport")]
    public float speed;
    public float carry0Amount;

    public float carry1Amount;

    public float carry2Amount;

    public  float canCarryAmount;

    public Transform townHall;
    public Transform transportPoint;

    public bool carryResource;
    public bool returning;

    public NavMeshAgent worker;

    void Start()
    {
        transportPoint = this.transform.parent;
        returning = true;
    }

    void Update()
    {
        StateMachine();

        speed = RawGen.deliverySpeed;
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
            canCarryAmount = RawGen.loadCapacity;
            moveToGen();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RawGen"))
        {
            loadRes2();
        }
        else if(other.CompareTag("TownHall"))
        {
            unloadResource();
        }
    }

    public void loadRes2()
    {
        if(RawGen.res2Mined >= canCarryAmount && !carryResource)
        {
            print("loading");
            carry2Amount += canCarryAmount;
            RawGen.res2Mined -= carry2Amount;
            canCarryAmount -= carry2Amount;

            returning = false;
            carryResource = true;
        }
        else if(RawGen.res2Mined <= canCarryAmount && !carryResource)
        {
            carry2Amount += RawGen.res2Mined;
            RawGen.res2Mined -= carry2Amount;
            canCarryAmount -= carry2Amount;

            loadRes1();
        }
    }

    public void loadRes1()
    {
        if(RawGen.res1Mined > canCarryAmount)
        {
            carry1Amount += canCarryAmount;
            RawGen.res1Mined -= carry1Amount;
            canCarryAmount -= carry1Amount;

            returning = false;
            carryResource = true;
        }
        else if(RawGen.res1Mined <= canCarryAmount)
        {
            carry1Amount += RawGen.res1Mined;
            RawGen.res1Mined -= carry1Amount;
            canCarryAmount -= carry1Amount;

            loadRes0();
        }
    }

    public void loadRes0()
    {
        if(RawGen.res0Mined >= canCarryAmount)
        {
            carry0Amount += canCarryAmount;
            RawGen.res0Mined -= carry0Amount;
            canCarryAmount -= carry0Amount;

            returning = false;
            carryResource = true;
        }
        else if(RawGen.res0Mined <= canCarryAmount)
        {
            carry0Amount += RawGen.res0Mined;
            RawGen.res0Mined -= carry0Amount;
            canCarryAmount -= carry0Amount;

            returning = false;
            carryResource = true;
        }
        else if(RawGen.res0Mined == 0)
        {
            return;
        }
    }

    public void unloadResource()
    {
        if(carry0Amount >= 1)
        {
            res0.resAmount += carry0Amount;
        }

        if(carry1Amount >= 1)
        {
            res1.resAmount += carry1Amount;
        }

        if(carry2Amount >= 1)
        {
            res2.resAmount += carry2Amount;
        }

        carry0Amount -= carry0Amount;
        carry1Amount -= carry1Amount;
        carry2Amount -= carry2Amount;
        

        returning = true;
        carryResource = false;
    }

    public void moveToGen()
    {
        worker.SetDestination(transportPoint.transform.position);
    }
}
