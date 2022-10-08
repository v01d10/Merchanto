using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform target;
    public Vector3 direction;

    void Update()
    {
        transform.LookAt(target, Vector3.up);
    }
}
