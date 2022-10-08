using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static townHall;
using static rawGenerator;
using static buildStateManager;

public class rawTransport : MonoBehaviour
{
    public int rawParentID;

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
        townHall = TownHall.THtransportArea;
        transportPoint = this.transform.parent;
        returning = true;
    }

    void Update()
    {
        StateMachine();

        speed = bsManager.rawGenList[rawParentID].delSpeed;
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
            canCarryAmount = bsManager.rawGenList[rawParentID].loadCap;
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
        if(bsManager.rawGenList[rawParentID].res2Mined >= canCarryAmount && !carryResource)
        {
            print("loading");
            carry2Amount += canCarryAmount;
            bsManager.rawGenList[rawParentID].res2Mined -= carry2Amount;
            canCarryAmount -= carry2Amount;

            returning = false;
            carryResource = true;
        }
        else if(bsManager.rawGenList[rawParentID].res2Mined <= canCarryAmount && !carryResource)
        {
            carry2Amount += bsManager.rawGenList[rawParentID].res2Mined;
            bsManager.rawGenList[rawParentID].res2Mined -= carry2Amount;
            canCarryAmount -= carry2Amount;

            loadRes1();
        }
    }

    public void loadRes1()
    {
        if(bsManager.rawGenList[rawParentID].res1Mined > canCarryAmount)
        {
            carry1Amount += canCarryAmount;
            bsManager.rawGenList[rawParentID].res1Mined -= carry1Amount;
            canCarryAmount -= carry1Amount;

            returning = false;
            carryResource = true;
        }
        else if(bsManager.rawGenList[rawParentID].res1Mined <= canCarryAmount)
        {
            carry1Amount += bsManager.rawGenList[rawParentID].res1Mined;
            bsManager.rawGenList[rawParentID].res1Mined -= carry1Amount;
            canCarryAmount -= carry1Amount;

            loadRes0();
        }
    }

    public void loadRes0()
    {
        if(bsManager.rawGenList[rawParentID].res0Mined >= canCarryAmount)
        {
            print("Loading raw" + rawParentID);
            carry0Amount += canCarryAmount;
            bsManager.rawGenList[rawParentID].res0Mined -= carry0Amount;
            canCarryAmount -= carry0Amount;

            returning = false;
            carryResource = true;
        }
        else if(bsManager.rawGenList[rawParentID].res0Mined <= canCarryAmount)
        {
            print("Loading raw" + rawParentID);
            carry0Amount += bsManager.rawGenList[rawParentID].res0Mined;
            bsManager.rawGenList[rawParentID].res0Mined -= carry0Amount;
            canCarryAmount -= carry0Amount;

            returning = false;
            carryResource = true;
        }
        else if(bsManager.rawGenList[rawParentID].res0Mined == 0)
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
