using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class researchUpgrades : MonoBehaviour
{
}

public abstract class Upgrade
{
    public abstract void Do();
}

public class upgrade0 : Upgrade
{
    public override void Do()
    {
        Debug.Log("upgrade0 acquired");
    }
}

public class upgrade1 : Upgrade
{
    public override void Do()
    {
        Debug.Log("upgrade0 acquired");
    }
}


