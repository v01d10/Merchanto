using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class townfolksNav : MonoBehaviour
{
    public Transform nextTarget;

    public List<Transform> targets;

    public NavMeshAgent agent;
    public Collider townfolk;
    public bool reachedTarget = true;
    public bool moving;

    void Start()
    {
        moveToTarget();
        moving = false;
    }

    public void moveToTarget()
    {   
        if(!moving)
        {
            nextTarget = targets[Random.Range(0, targets.Count)];
            agent.SetDestination(nextTarget.position);
            moving = true;
        }
    }

    public void findNextTarget()
    {
        if(reachedTarget)
        {
            reachedTarget = false;
            moving = false;
            moveToTarget();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TownfolkTarget"))
        {
            reachedTarget = true;
            findNextTarget();

        }
    }
}
