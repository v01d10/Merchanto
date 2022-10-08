using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static townfolk;

[System.Serializable]
public class townfolkManager : MonoBehaviour
{
    public float freeTownfolksAmount;
    public float townfolksMax;

    public float totalHappiness;

    public static List<townfolk> Townfolks = new List<townfolk>();

    public List<string> mNames = new List<string>();
    public List<string> fNames = new List<string>();

    public List<GameObject> mPrefabs = new List<GameObject>();
    public List<GameObject> fPrefabs = new List<GameObject>();

    public List<Transform> wanderTargets;

    void Start()
    {
        for (int i = 0; i < townfolksMax; i++)
        {
            spawnFolk();
        }
    }

    public void spawnFolk()
    {
        int mPrefabID = UnityEngine.Random.Range(0, mPrefabs.Count);
        int fPrefabID = UnityEngine.Random.Range(0, fPrefabs.Count);
        
        Instantiate(mPrefabs[mPrefabID], this.transform);
    }

    public void addFolk(townfolk folk)
    {
        Townfolks.Add(folk);
    } 
}
